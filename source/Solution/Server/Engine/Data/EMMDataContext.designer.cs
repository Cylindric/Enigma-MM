﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnigmaMM.Engine.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="data")]
	public partial class EMMDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertConfig(Config instance);
    partial void UpdateConfig(Config instance);
    partial void DeleteConfig(Config instance);
    partial void InsertItemHistory(ItemHistory instance);
    partial void UpdateItemHistory(ItemHistory instance);
    partial void DeleteItemHistory(ItemHistory instance);
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    partial void InsertMessageType(MessageType instance);
    partial void UpdateMessageType(MessageType instance);
    partial void DeleteMessageType(MessageType instance);
    partial void InsertPermission(Permission instance);
    partial void UpdatePermission(Permission instance);
    partial void DeletePermission(Permission instance);
    partial void InsertRank(Rank instance);
    partial void UpdateRank(Rank instance);
    partial void DeleteRank(Rank instance);
    partial void InsertTracking(Tracking instance);
    partial void UpdateTracking(Tracking instance);
    partial void DeleteTracking(Tracking instance);
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
		
		public System.Data.Linq.Table<ItemHistory> ItemHistories
		{
			get
			{
				return this.GetTable<ItemHistory>();
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
		
		public System.Data.Linq.Table<Permission> Permissions
		{
			get
			{
				return this.GetTable<Permission>();
			}
		}
		
		public System.Data.Linq.Table<Rank> Ranks
		{
			get
			{
				return this.GetTable<Rank>();
			}
		}
		
		public System.Data.Linq.Table<Tracking> Trackings
		{
			get
			{
				return this.GetTable<Tracking>();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class ItemHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ItemHistory_ID;
		
		private int _Item_ID;
		
		private int _User_ID;
		
		private int _Quantity;
		
		private System.DateTime _CreateDate;
		
		private EntityRef<Item> _Item;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItemHistory_IDChanging(int value);
    partial void OnItemHistory_IDChanged();
    partial void OnItem_IDChanging(int value);
    partial void OnItem_IDChanged();
    partial void OnUser_IDChanging(int value);
    partial void OnUser_IDChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnCreateDateChanging(System.DateTime value);
    partial void OnCreateDateChanged();
    #endregion
		
		public ItemHistory()
		{
			this._Item = default(EntityRef<Item>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemHistory_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ItemHistory_ID
		{
			get
			{
				return this._ItemHistory_ID;
			}
			set
			{
				if ((this._ItemHistory_ID != value))
				{
					this.OnItemHistory_IDChanging(value);
					this.SendPropertyChanging();
					this._ItemHistory_ID = value;
					this.SendPropertyChanged("ItemHistory_ID");
					this.OnItemHistory_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Item_ID", DbType="Int NOT NULL")]
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
					if (this._Item.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnItem_IDChanging(value);
					this.SendPropertyChanging();
					this._Item_ID = value;
					this.SendPropertyChanged("Item_ID");
					this.OnItem_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", DbType="Int NOT NULL")]
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
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_ItemHistory", Storage="_Item", ThisKey="Item_ID", OtherKey="Item_ID", IsForeignKey=true)]
		public Item Item
		{
			get
			{
				return this._Item.Entity;
			}
			set
			{
				Item previousValue = this._Item.Entity;
				if (((previousValue != value) 
							|| (this._Item.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Item.Entity = null;
						previousValue.ItemHistories.Remove(this);
					}
					this._Item.Entity = value;
					if ((value != null))
					{
						value.ItemHistories.Add(this);
						this._Item_ID = value.Item_ID;
					}
					else
					{
						this._Item_ID = default(int);
					}
					this.SendPropertyChanged("Item");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ItemHistory", Storage="_User", ThisKey="User_ID", OtherKey="User_ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.ItemHistories.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.ItemHistories.Add(this);
						this._User_ID = value.User_ID;
					}
					else
					{
						this._User_ID = default(int);
					}
					this.SendPropertyChanged("User");
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
		
		private int _Block_Decimal_ID;
		
		private string _Name;
		
		private int _Stack_Size;
		
		private int _Max;
		
		private int _Min_Level;
		
		private EntitySet<ItemHistory> _ItemHistories;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItem_IDChanging(int value);
    partial void OnItem_IDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnBlock_Decimal_IDChanging(int value);
    partial void OnBlock_Decimal_IDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnStack_SizeChanging(int value);
    partial void OnStack_SizeChanged();
    partial void OnMaxChanging(int value);
    partial void OnMaxChanged();
    partial void OnMin_LevelChanging(int value);
    partial void OnMin_LevelChanged();
    #endregion
		
		public Item()
		{
			this._ItemHistories = new EntitySet<ItemHistory>(new Action<ItemHistory>(this.attach_ItemHistories), new Action<ItemHistory>(this.detach_ItemHistories));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Block_Decimal_ID", DbType="Int NOT NULL")]
		public int Block_Decimal_ID
		{
			get
			{
				return this._Block_Decimal_ID;
			}
			set
			{
				if ((this._Block_Decimal_ID != value))
				{
					this.OnBlock_Decimal_IDChanging(value);
					this.SendPropertyChanging();
					this._Block_Decimal_ID = value;
					this.SendPropertyChanged("Block_Decimal_ID");
					this.OnBlock_Decimal_IDChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Min_Level", DbType="Int NOT NULL")]
		public int Min_Level
		{
			get
			{
				return this._Min_Level;
			}
			set
			{
				if ((this._Min_Level != value))
				{
					this.OnMin_LevelChanging(value);
					this.SendPropertyChanging();
					this._Min_Level = value;
					this.SendPropertyChanged("Min_Level");
					this.OnMin_LevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Item_ItemHistory", Storage="_ItemHistories", ThisKey="Item_ID", OtherKey="Item_ID")]
		public EntitySet<ItemHistory> ItemHistories
		{
			get
			{
				return this._ItemHistories;
			}
			set
			{
				this._ItemHistories.Assign(value);
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
		
		private void attach_ItemHistories(ItemHistory entity)
		{
			this.SendPropertyChanging();
			entity.Item = this;
		}
		
		private void detach_ItemHistories(ItemHistory entity)
		{
			this.SendPropertyChanging();
			entity.Item = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="MessageTypes")]
	public partial class MessageType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Message_Type_ID;
		
		private string _Name;
		
		private string _Expression;
		
		private string _MatchType;
		
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
    partial void OnMatchTypeChanging(string value);
    partial void OnMatchTypeChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Expression", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatchType", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string MatchType
		{
			get
			{
				return this._MatchType;
			}
			set
			{
				if ((this._MatchType != value))
				{
					this.OnMatchTypeChanging(value);
					this.SendPropertyChanging();
					this._MatchType = value;
					this.SendPropertyChanged("MatchType");
					this.OnMatchTypeChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Permissions")]
	public partial class Permission : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Permission_ID;
		
		private int _Min_Level;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPermission_IDChanging(int value);
    partial void OnPermission_IDChanged();
    partial void OnMin_LevelChanging(int value);
    partial void OnMin_LevelChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Permission()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Permission_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Permission_ID
		{
			get
			{
				return this._Permission_ID;
			}
			set
			{
				if ((this._Permission_ID != value))
				{
					this.OnPermission_IDChanging(value);
					this.SendPropertyChanging();
					this._Permission_ID = value;
					this.SendPropertyChanged("Permission_ID");
					this.OnPermission_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Min_Level", DbType="Int NOT NULL")]
		public int Min_Level
		{
			get
			{
				return this._Min_Level;
			}
			set
			{
				if ((this._Min_Level != value))
				{
					this.OnMin_LevelChanging(value);
					this.SendPropertyChanging();
					this._Min_Level = value;
					this.SendPropertyChanged("Min_Level");
					this.OnMin_LevelChanged();
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
		
		private int _Level;
		
		private string _Name;
		
		private EntitySet<User> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRank_IDChanging(int value);
    partial void OnRank_IDChanged();
    partial void OnLevelChanging(int value);
    partial void OnLevelChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Rank()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Level", DbType="Int NOT NULL")]
		public int Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._Level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Tracking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Tracking_ID;
		
		private int _User_ID;
		
		private int _LocX;
		
		private int _LocY;
		
		private int _LocZ;
		
		private System.Nullable<System.DateTime> _PointTime;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTracking_IDChanging(int value);
    partial void OnTracking_IDChanged();
    partial void OnUser_IDChanging(int value);
    partial void OnUser_IDChanged();
    partial void OnLocXChanging(int value);
    partial void OnLocXChanged();
    partial void OnLocYChanging(int value);
    partial void OnLocYChanged();
    partial void OnLocZChanging(int value);
    partial void OnLocZChanged();
    partial void OnPointTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnPointTimeChanged();
    #endregion
		
		public Tracking()
		{
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tracking_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Tracking_ID
		{
			get
			{
				return this._Tracking_ID;
			}
			set
			{
				if ((this._Tracking_ID != value))
				{
					this.OnTracking_IDChanging(value);
					this.SendPropertyChanging();
					this._Tracking_ID = value;
					this.SendPropertyChanged("Tracking_ID");
					this.OnTracking_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", DbType="Int NOT NULL")]
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
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocX", DbType="Int NOT NULL")]
		public int LocX
		{
			get
			{
				return this._LocX;
			}
			set
			{
				if ((this._LocX != value))
				{
					this.OnLocXChanging(value);
					this.SendPropertyChanging();
					this._LocX = value;
					this.SendPropertyChanged("LocX");
					this.OnLocXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocY", DbType="Int NOT NULL")]
		public int LocY
		{
			get
			{
				return this._LocY;
			}
			set
			{
				if ((this._LocY != value))
				{
					this.OnLocYChanging(value);
					this.SendPropertyChanging();
					this._LocY = value;
					this.SendPropertyChanged("LocY");
					this.OnLocYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocZ", DbType="Int NOT NULL")]
		public int LocZ
		{
			get
			{
				return this._LocZ;
			}
			set
			{
				if ((this._LocZ != value))
				{
					this.OnLocZChanging(value);
					this.SendPropertyChanging();
					this._LocZ = value;
					this.SendPropertyChanged("LocZ");
					this.OnLocZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PointTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> PointTime
		{
			get
			{
				return this._PointTime;
			}
			set
			{
				if ((this._PointTime != value))
				{
					this.OnPointTimeChanging(value);
					this.SendPropertyChanging();
					this._PointTime = value;
					this.SendPropertyChanged("PointTime");
					this.OnPointTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Tracking", Storage="_User", ThisKey="User_ID", OtherKey="User_ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Trackings.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Trackings.Add(this);
						this._User_ID = value.User_ID;
					}
					else
					{
						this._User_ID = default(int);
					}
					this.SendPropertyChanged("User");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _User_ID;
		
		private int _Rank_ID;
		
		private string _Username;
		
		private int _LocX;
		
		private int _LocY;
		
		private int _LocZ;
		
		private System.Nullable<System.DateTime> _LastSeen;
		
		private EntitySet<ItemHistory> _ItemHistories;
		
		private EntitySet<Tracking> _Trackings;
		
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
    partial void OnLocXChanging(int value);
    partial void OnLocXChanged();
    partial void OnLocYChanging(int value);
    partial void OnLocYChanged();
    partial void OnLocZChanging(int value);
    partial void OnLocZChanged();
    partial void OnLastSeenChanging(System.Nullable<System.DateTime> value);
    partial void OnLastSeenChanged();
    #endregion
		
		public User()
		{
			this._ItemHistories = new EntitySet<ItemHistory>(new Action<ItemHistory>(this.attach_ItemHistories), new Action<ItemHistory>(this.detach_ItemHistories));
			this._Trackings = new EntitySet<Tracking>(new Action<Tracking>(this.attach_Trackings), new Action<Tracking>(this.detach_Trackings));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocX", DbType="Int NOT NULL")]
		public int LocX
		{
			get
			{
				return this._LocX;
			}
			set
			{
				if ((this._LocX != value))
				{
					this.OnLocXChanging(value);
					this.SendPropertyChanging();
					this._LocX = value;
					this.SendPropertyChanged("LocX");
					this.OnLocXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocY", DbType="Int NOT NULL")]
		public int LocY
		{
			get
			{
				return this._LocY;
			}
			set
			{
				if ((this._LocY != value))
				{
					this.OnLocYChanging(value);
					this.SendPropertyChanging();
					this._LocY = value;
					this.SendPropertyChanged("LocY");
					this.OnLocYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocZ", DbType="Int NOT NULL")]
		public int LocZ
		{
			get
			{
				return this._LocZ;
			}
			set
			{
				if ((this._LocZ != value))
				{
					this.OnLocZChanging(value);
					this.SendPropertyChanging();
					this._LocZ = value;
					this.SendPropertyChanged("LocZ");
					this.OnLocZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastSeen", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastSeen
		{
			get
			{
				return this._LastSeen;
			}
			set
			{
				if ((this._LastSeen != value))
				{
					this.OnLastSeenChanging(value);
					this.SendPropertyChanging();
					this._LastSeen = value;
					this.SendPropertyChanged("LastSeen");
					this.OnLastSeenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ItemHistory", Storage="_ItemHistories", ThisKey="User_ID", OtherKey="User_ID")]
		public EntitySet<ItemHistory> ItemHistories
		{
			get
			{
				return this._ItemHistories;
			}
			set
			{
				this._ItemHistories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Tracking", Storage="_Trackings", ThisKey="User_ID", OtherKey="User_ID")]
		public EntitySet<Tracking> Trackings
		{
			get
			{
				return this._Trackings;
			}
			set
			{
				this._Trackings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Rank_User", Storage="_Rank", ThisKey="Rank_ID", OtherKey="Rank_ID", IsForeignKey=true, DeleteOnNull=true)]
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
		
		private void attach_ItemHistories(ItemHistory entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_ItemHistories(ItemHistory entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Trackings(Tracking entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Trackings(Tracking entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591
