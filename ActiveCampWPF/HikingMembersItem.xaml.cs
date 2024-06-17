﻿using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для HikingMembersItem.xaml
    /// </summary>
    public partial class HikingMembersItem : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private UserProfile _profile;
        private GroupMembership _membership;

        public UserProfile Profile
        {
            get { return _profile; }
            
            set
            {
                _profile = value;
                NotifyPropertyChanged(nameof(Profile));
            }
        }

        public GroupMembership Membership
        {
            get => _membership;
            set
            {
                if (value != _membership)
                {
                    _membership = value;
                    NotifyPropertyChanged(nameof(Membership));
                }
            }
        }

        public HikingMembersItem(GroupMembership membership, UserProfile userProfile)
        {
            InitializeComponent();
            _membership = membership;
            _profile = userProfile;
        }

        private HikingMembersItem temp_Record = null;
        private bool m_Editing = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as HikingMembersItem;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._profile = temp_Record.Profile;
                _membership = temp_Record.Membership;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }

        private void AgreeButton_Click(object sender, RoutedEventArgs e)
        {
            Membership.IsAproved = true;
            GroupMembershipManager manager = new GroupMembershipManager();
            manager.UpdateGroupMembership(Membership);
        }

        private void disagreeButton_Click(object sender, RoutedEventArgs e)
        {
            GroupMembershipManager manager = new GroupMembershipManager();
            manager.DeleteGroupMembership(Membership.UserId, Membership.GroupId);
        }
    }
}
