﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnigmaMM.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EMM")]
	public partial class EMMDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertConfig(Config instance);
    partial void UpdateConfig(Config instance);
    partial void DeleteConfig(Config instance);
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    partial void InsertMessageType(MessageType instance);
    partial void UpdateMessageType(MessageType instance);
    partial void DeleteMessageType(MessageType instance);
    partial void InsertRank(Rank instance);
    partial void UpdateRank(Rank instance);
    partial void DeleteRank(Rank instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public EMMDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EMMDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EMMDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EMMDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Config> Configs
		{
			get
			{
				return this.GetTable<Config>();
			}
		}
		
		public System.Data.Linq.Table<Item> Items
		{
			get
			{
				return this.GetTable<Item>();
			}
		}
		
		public System.Data.Linq.Table<MessageType> MessageTypes
		{
			get
			{
				return this.GetTable<MessageType>();
			}
		}
		
		public System.Data.Linq.Table<Rank> Ranks
		{
			get
			{
				return this.GetTable<Rank>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Config : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Config_ID;
		
		private string _Key;
		
		private string _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConfig_IDChanging(int value);
    partial void OnConfig_IDChanged();
    partial void OnKeyChanging(string value);
    partial void OnKeyChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    #endregion
		
		public Config()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Config_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Config_ID
		{
			get
			{
				return this._Config_ID;
			}
			set
			{
				if ((this._Config_ID != value))
				{
					this.OnConfig_IDChanging(value);
					this.SendPropertyChanging();
					this._Config_ID = value;
					this.SendPropertyChanged("Config_ID");
					this.OnConfig_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Key", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				if ((this._Key != value))
				{
					this.OnKeyChanging(value);
					this.SendPropertyChanging();
					this._Key = value;
					this.SendPropertyChanged("Key");
					this.OnKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Items")]
	public partial class Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Item_ID;
		
		private string _Code;
		
		private string _Name;
		
		private int _Stack_Size;
		
		private int _Max;
		
		private int _Min_Rank_ID;
		
		private EntityRef<Rank> _Rank;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItem_IDChanging(int value);
    partial void OnItem_IDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnStack_SizeChanging(int value);
    partial void OnStack_SizeChanged();
    partial void OnMaxChanging(int value);
    partial void OnMaxChanged();
    partial void OnMin_Rank_IDChanging(int value);
    partial void OnMin_Rank_IDChanged();
    #endregion
		
		public Item()
		{
			this._Rank = default(EntityRef<Rank>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Item_ID
		{
			get
			{
				return this._Item_ID;
			}
			set
			{
				if ((this._Item_ID != value))
				{
					this.OnItem_IDChanging(value);
					this.SendPropertyChanging();
					this._Item_ID = value;
					this.SendPropertyChanged("Item_ID");
					this.OnItem_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stack_Size", DbType="Int NOT NULL")]
		public int Stack_Size
		{
			get
			{
				return this._Stack_Size;
			}
			set
			{
				if ((this._Stack_Size != value))
				{
					this.OnStack_SizeChanging(value);
					this.SendPropertyChanging();
					this._Stack_Size = value;
					this.SendPropertyChanged("Stack_Size");
					this.OnStack_SizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max", DbType="Int NOT NULL")]
		public int Max
		{
			get
			{
				return this._Max;
			}
			set
			{
				if ((this._Max != value))
				{
					this.OnMaxChanging(value);
					this.SendPropertyChanging();
					this._Max = value;
					this.SendPropertyChanged("Max");
					this.OnMaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Min_Rank_ID", DbType="Int NOT NULL")]
		public int Min_Rank_ID
		{
			get
			{
				return this._Min_Rank_ID;
			}
			set
			{
				if ((this._Min_Rank_ID != value))
				{
					if (this._Rank.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMin_Rank_IDChanging(value);
					this.SendPropertyChanging();
					this._Min_Rank_ID = value;
					this.SendPropertyChanged("Min_Rank_ID");
					this.OnMin_Rank_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Rank_Item", Storage="_Rank", ThisKey="Min_Rank_ID", OtherKey="Rank_ID", IsForeignKey=true)]
		public Rank Rank
		{
			get
			{
				return this._Rank.Entity;
			}
			set
			{
				Rank previousValue = this._Rank.Entity;
				if (((previousValue != value) 
							|| (this._Rank.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Rank.Entity = null;
						previousValue.Items.Remove(this);
					}
					this._Rank.Entity = value;
					if ((value != null))
					{
						value.Items.Add(this);
						this._Min_Rank_ID = value.Rank_ID;
					}
					else
					{
						this._Min_Rank_ID = default(int);
					}
					this.SendPropertyChanged("Rank");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="MessageTypes")]
	public partial class MessageType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Message_Type_ID;
		
		private string _Name;
		
		private string _Expression;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMessage_Type_IDChanging(int value);
    partial void OnMessage_Type_IDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnExpressionChanging(string value);
    partial void OnExpressionChanged();
    #endregion
		
		public MessageType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message_Type_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Message_Type_ID
		{
			get
			{
				return this._Message_Type_ID;
			}
			set
			{
				if ((this._Message_Type_ID != value))
				{
					this.OnMessage_Type_IDChanging(value);
					this.SendPropertyChanging();
					this._Message_Type_ID = value;
					this.SendPropertyChanged("Message_Type_ID");
					this.OnMessage_Type_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Expression", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Expression
		{
			get
			{
				return this._Expression;
			}
			set
			{
				if ((this._Expression != value))
				{
					this.OnExpressionChanging(value);
					this.SendPropertyChanging();
					this._Expression = value;
					this.SendPropertyChanged("Expression");
					this.OnExpressionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Ranks")]
	public partial class Rank : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Rank_ID;
		
		private string _Name;
		
		private EntitySet<Item> _Items;
		
		private EntitySet<User> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRank_IDChanging(int value);
    partial void OnRank_IDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Rank()
		{
			this._Items = new EntitySet<Item>(new Action<Item>(this.attach_Items), new Action<Item>(this.detach_Items));
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rank_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Rank_ID
		{
			get
			{
				return this._Rank_ID;
			}
			set
			{
				if ((this._Rank_ID != value))
				{
					this.OnRank_IDChanging(value);
					this.SendPropertyChanging();
					this._Rank_ID = value;
					this.SendPropertyChanged("Rank_ID");
					this.OnRank_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Rank_Item", Storage="_Items", ThisKey="Rank_ID", OtherKey="Min_Rank_ID")]
		public EntitySet<Item> Items
		{
			get
			{
				return this._Items;
			}
			set
			{
				this._Items.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Rank_User", Storage="_Users", ThisKey="Rank_ID", OtherKey="Rank_ID")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Rank = this;
		}
		
		private void detach_Items(Item entity)
		{
			this.SendPropertyChanging();
			entity.Rank = null;
		}
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Rank = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Rank = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _User_ID;
		
		private int _Rank_ID;
		
		private string _Username;
		
		private EntityRef<Rank> _Rank;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUser_IDChanging(int value);
    partial void OnUser_IDChanged();
    partial void OnRank_IDChanging(int value);
    partial void OnRank_IDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    #endregion
		
		public User()
		{
			this._Rank = default(EntityRef<Rank>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int User_ID
		{
			get
			{
				return this._User_ID;
			}
			set
			{
				if ((this._User_ID != value))
				{
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rank_ID", DbType="Int NOT NULL")]
		public int Rank_ID
		{
			get
			{
				return this._Rank_ID;
			}
			set
			{
				if ((this._Rank_ID != value))
				{
					if (this._Rank.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRank_IDChanging(value);
					this.SendPropertyChanging();
					this._Rank_ID = value;
					this.SendPropertyChanged("Rank_ID");
					this.OnRank_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Rank_User", Storage="_Rank", ThisKey="Rank_ID", OtherKey="Rank_ID", IsForeignKey=true)]
		public Rank Rank
		{
			get
			{
				return this._Rank.Entity;
			}
			set
			{
				Rank previousValue = this._Rank.Entity;
				if (((previousValue != value) 
							|| (this._Rank.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Rank.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Rank.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._Rank_ID = value.Rank_ID;
					}
					else
					{
						this._Rank_ID = default(int);
					}
					this.SendPropertyChanged("Rank");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
