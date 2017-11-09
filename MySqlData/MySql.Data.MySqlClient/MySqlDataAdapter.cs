using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;

namespace MySql.Data.MySqlClient
{
	[Designer("MySql.Data.MySqlClient.Design.MySqlDataAdapterDesigner,MySqlClient.Design"), DesignerCategory("Code"), ToolboxBitmap(typeof(MySqlDataAdapter), "MySqlClient.resources.dataadapter.bmp")]
	public sealed class MySqlDataAdapter : DbDataAdapter, IDbDataAdapter, IDataAdapter
	{
		private MySqlCommand m_selectCommand;

		private MySqlCommand m_insertCommand;

		private MySqlCommand m_updateCommand;

		private MySqlCommand m_deleteCommand;

		private bool loadingDefaults;

		private static readonly object EventRowUpdated = new object();

		private static readonly object EventRowUpdating = new object();

		public event MySqlRowUpdatingEventHandler RowUpdating
		{
			add
			{
				base.get_Events().AddHandler(MySqlDataAdapter.EventRowUpdating, value);
			}
			remove
			{
				base.get_Events().RemoveHandler(MySqlDataAdapter.EventRowUpdating, value);
			}
		}

		public event MySqlRowUpdatedEventHandler RowUpdated
		{
			add
			{
				base.get_Events().AddHandler(MySqlDataAdapter.EventRowUpdated, value);
			}
			remove
			{
				base.get_Events().RemoveHandler(MySqlDataAdapter.EventRowUpdated, value);
			}
		}

		[Description("Used during Update for deleted rows in Dataset.")]
		public MySqlCommand DeleteCommand
		{
			get
			{
				return this.m_deleteCommand;
			}
			set
			{
				this.m_deleteCommand = value;
			}
		}

		IDbCommand IDbDataAdapter.DeleteCommand
		{
			get
			{
				return this.m_deleteCommand;
			}
			set
			{
				this.m_deleteCommand = (MySqlCommand)value;
			}
		}

		[Description("Used during Update for new rows in Dataset.")]
		public MySqlCommand InsertCommand
		{
			get
			{
				return this.m_insertCommand;
			}
			set
			{
				this.m_insertCommand = value;
			}
		}

		IDbCommand IDbDataAdapter.InsertCommand
		{
			get
			{
				return this.m_insertCommand;
			}
			set
			{
				this.m_insertCommand = (MySqlCommand)value;
			}
		}

		[Category("Fill"), Description("Used during Fill/FillSchema")]
		public MySqlCommand SelectCommand
		{
			get
			{
				return this.m_selectCommand;
			}
			set
			{
				this.m_selectCommand = value;
			}
		}

		IDbCommand IDbDataAdapter.SelectCommand
		{
			get
			{
				return this.m_selectCommand;
			}
			set
			{
				this.m_selectCommand = (MySqlCommand)value;
			}
		}

		[Description("Used during Update for modified rows in Dataset.")]
		public MySqlCommand UpdateCommand
		{
			get
			{
				return this.m_updateCommand;
			}
			set
			{
				this.m_updateCommand = value;
			}
		}

		IDbCommand IDbDataAdapter.UpdateCommand
		{
			get
			{
				return this.m_updateCommand;
			}
			set
			{
				this.m_updateCommand = (MySqlCommand)value;
			}
		}

		internal bool LoadDefaults
		{
			get
			{
				return this.loadingDefaults;
			}
			set
			{
				this.loadingDefaults = value;
			}
		}

		public MySqlDataAdapter()
		{
			this.loadingDefaults = true;
		}

		public MySqlDataAdapter(MySqlCommand selectCommand) : this()
		{
			this.SelectCommand = selectCommand;
		}

		public MySqlDataAdapter(string selectCommandText, MySqlConnection connection) : this()
		{
			this.SelectCommand = new MySqlCommand(selectCommandText, connection);
		}

		public MySqlDataAdapter(string selectCommandText, string selectConnString) : this()
		{
			this.SelectCommand = new MySqlCommand(selectCommandText, new MySqlConnection(selectConnString));
		}

		protected override RowUpdatedEventArgs CreateRowUpdatedEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		{
			return new MySqlRowUpdatedEventArgs(dataRow, command, statementType, tableMapping);
		}

		protected override RowUpdatingEventArgs CreateRowUpdatingEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		{
			return new MySqlRowUpdatingEventArgs(dataRow, command, statementType, tableMapping);
		}

		protected override void OnRowUpdating(RowUpdatingEventArgs value)
		{
			MySqlRowUpdatingEventArgs mySqlRowUpdatingEventArgs = value as MySqlRowUpdatingEventArgs;
			MySqlRowUpdatingEventHandler mySqlRowUpdatingEventHandler = (MySqlRowUpdatingEventHandler)base.get_Events().get_Item(MySqlDataAdapter.EventRowUpdating);
			if (mySqlRowUpdatingEventHandler != null && mySqlRowUpdatingEventArgs != null)
			{
				mySqlRowUpdatingEventHandler(this, mySqlRowUpdatingEventArgs);
			}
		}

		protected override void OnRowUpdated(RowUpdatedEventArgs value)
		{
			MySqlRowUpdatedEventArgs mySqlRowUpdatedEventArgs = value as MySqlRowUpdatedEventArgs;
			MySqlRowUpdatedEventHandler mySqlRowUpdatedEventHandler = (MySqlRowUpdatedEventHandler)base.get_Events().get_Item(MySqlDataAdapter.EventRowUpdated);
			if (mySqlRowUpdatedEventHandler != null && mySqlRowUpdatedEventArgs != null)
			{
				mySqlRowUpdatedEventHandler(this, mySqlRowUpdatedEventArgs);
			}
		}
	}
}
