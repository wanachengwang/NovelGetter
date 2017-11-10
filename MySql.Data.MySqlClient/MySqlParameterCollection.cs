using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;

namespace MySql.Data.MySqlClient
{
	[Editor("MySql.Data.MySqlClient.Design.DBParametersEditor,MySql.Design", typeof(UITypeEditor)), ListBindable(true)]
	public sealed class MySqlParameterCollection : MarshalByRefObject, IEnumerable, IDataParameterCollection, IList, ICollection
	{
		private ArrayList _parms = new ArrayList();

		private char paramMarker = '?';

		private Hashtable ciHash;

		private Hashtable hash;

		private int returnParameterIndex;

		internal char ParameterMarker
		{
			get
			{
				return this.paramMarker;
			}
			set
			{
				this.paramMarker = value;
			}
		}

		public int Count
		{
			get
			{
				return this._parms.Count;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return this._parms.IsSynchronized;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return this._parms.SyncRoot;
			}
		}

		bool IList.IsFixedSize
		{
			get
			{
				return this._parms.IsFixedSize;
			}
		}

		bool IList.IsReadOnly
		{
			get
			{
				return this._parms.IsReadOnly;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (!(value is MySqlParameter))
				{
					throw new MySqlException("Only MySqlParameter objects may be stored");
				}
				this[index] = (MySqlParameter)value;
			}
		}

		object IDataParameterCollection.this[string name]
		{
			get
			{
				return this[name];
			}
			set
			{
				if (!(value is MySqlParameter))
				{
					throw new MySqlException("Only MySqlParameter objects may be stored");
				}
				this[name] = (MySqlParameter)value;
			}
		}

		public MySqlParameter this[int index]
		{
			get
			{
				return (MySqlParameter)this._parms[index];
			}
			set
			{
				MySqlParameter mySqlParameter = (MySqlParameter)this._parms[index];
				if (mySqlParameter.Direction == (ParameterDirection)6)
				{
					this.returnParameterIndex = -1;
				}
				else
				{
					this.ciHash.Remove(mySqlParameter.ParameterName);
					this.hash.Remove(mySqlParameter.ParameterName);
				}
				this._parms[index] = value;
				if (value.Direction == (ParameterDirection)6)
				{
					this.returnParameterIndex = index;
					return;
				}
				this.ciHash.Add(value.ParameterName, index);
				this.hash.Add(value.ParameterName, index);
			}
		}

		public MySqlParameter this[string name]
		{
			get
			{
				return (MySqlParameter)this._parms[this.InternalIndexOf(name)];
			}
			set
			{
				this[this.InternalIndexOf(name)] = value;
			}
		}

		internal MySqlParameterCollection()
		{
			this.hash = new Hashtable();
			this.ciHash = new Hashtable(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
			this.Clear();
		}

		private int InternalIndexOf(string name)
		{
			int num = this.IndexOf(name);
			if (num != -1)
			{
				return num;
			}
			if (name.StartsWith(this.ParameterMarker.ToString()))
			{
				string text = name.Substring(1);
				num = this.IndexOf(text);
				if (num != -1)
				{
					throw new ArgumentException(string.Format(Resources.WrongParameterName, name, text));
				}
			}
			throw new MySqlException("A MySqlParameter with ParameterName '" + name + "' is not contained by this MySqlParameterCollection.");
		}

		public void CopyTo(Array array, int index)
		{
			this._parms.CopyTo(array, index);
		}

		public void Clear()
		{
			foreach (Object o in this._parms)
			{
				MySqlParameter mySqlParameter = (MySqlParameter)o;
				mySqlParameter.Collection = null;
			}
			this._parms.Clear();
			this.hash.Clear();
			this.ciHash.Clear();
			this.returnParameterIndex = -1;
		}

		public bool Contains(object value)
		{
			return this._parms.Contains(value);
		}

		public int IndexOf(object value)
		{
			return this._parms.IndexOf(value);
		}

		public void Insert(int index, object value)
		{
			this._parms.Insert(index, value);
		}

		public void Remove(object value)
		{
			this._parms.Remove(value);
			MySqlParameter mySqlParameter = value as MySqlParameter;
			this.hash.Remove(mySqlParameter.ParameterName);
			this.ciHash.Remove(mySqlParameter.ParameterName);
			mySqlParameter.Collection = null;
			if ((int)mySqlParameter.Direction == 6)
			{
				this.returnParameterIndex = -1;
			}
		}

		public void RemoveAt(int index)
		{
			MySqlParameter value = this[index];
			this.Remove(value);
		}

		public int Add(object value)
		{
			if (!(value is MySqlParameter))
			{
				throw new MySqlException("Only MySqlParameter objects may be stored");
			}
			MySqlParameter mySqlParameter = (MySqlParameter)value;
			if (mySqlParameter.ParameterName == null || mySqlParameter.ParameterName == string.Empty)
			{
				throw new MySqlException("Parameters must be named");
			}
			mySqlParameter = this.Add(mySqlParameter);
			return this.IndexOf(mySqlParameter);
		}

		public bool Contains(string name)
		{
			return this.IndexOf(name) != -1;
		}

		public int IndexOf(string parameterName)
		{
			object obj = this.hash[parameterName];
			if (obj != null)
			{
				return (int)obj;
			}
			obj = this.ciHash[parameterName];
			if (obj != null)
			{
				return (int)obj;
			}
			if (this.returnParameterIndex != -1)
			{
				MySqlParameter mySqlParameter = (MySqlParameter)this._parms[this.returnParameterIndex];
				if (string.Compare(parameterName, mySqlParameter.ParameterName, true) == 0)
				{
					return this.returnParameterIndex;
				}
			}
			return -1;
		}

		public void RemoveAt(string name)
		{
			int index = this.InternalIndexOf(name);
			this.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._parms.GetEnumerator();
		}

		public MySqlParameter Add(MySqlParameter value)
		{
			if (value == null)
			{
				throw new ArgumentException("The MySqlParameterCollection only accepts non-null MySqlParameter type objects.", "value");
			}
			if ((int)value.Direction == 6)
			{
				return this.AddReturnParameter(value);
			}
			string text = value.ParameterName.ToLower();
			if (text[0] == this.paramMarker)
			{
				text = text.Substring(1, text.Length - 1);
			}
			for (int i = 0; i < this._parms.Count; i++)
			{
				MySqlParameter mySqlParameter = (MySqlParameter)this._parms[i];
				string text2 = mySqlParameter.ParameterName.ToLower();
				if (text2[0] == this.paramMarker)
				{
					text2 = text2.Substring(1, text2.Length - 1);
				}
				if (text2 == text)
				{
					throw new MySqlException(string.Format(Resources.ParameterAlreadyDefined, value.ParameterName));
				}
			}
			int num = this._parms.Add(value);
			this.hash.Add(value.ParameterName, num);
			this.ciHash.Add(value.ParameterName, num);
			value.Collection = this;
			return value;
		}

		private MySqlParameter AddReturnParameter(MySqlParameter value)
		{
			if (this.returnParameterIndex != -1)
			{
				throw new InvalidOperationException(Resources.ReturnParameterExists);
			}
			this.returnParameterIndex = this._parms.Add(value);
			return value;
		}

		public MySqlParameter Add(string parameterName, object value)
		{
			return this.Add(new MySqlParameter(parameterName, value));
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType)
		{
			return this.Add(new MySqlParameter(parameterName, dbType));
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType, int size)
		{
			return this.Add(new MySqlParameter(parameterName, dbType, size));
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType, int size, string sourceColumn)
		{
			return this.Add(new MySqlParameter(parameterName, dbType, size, sourceColumn));
		}

		internal void ParameterNameChanged(MySqlParameter p, string oldName, string newName)
		{
			if ((int)p.Direction == 6)
			{
				return;
			}
			int num = this.IndexOf(oldName);
			this.hash.Remove(oldName);
			this.ciHash.Remove(oldName);
			this.hash.Add(newName, num);
			this.ciHash.Add(newName, num);
		}
	}
}
