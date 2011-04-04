﻿/*
 * Copyright 2010-2011 ForNeVeR.
 *
 * This file is part of Hell API.
 *
 * Hell API is free software: you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License as published by the Free
 * Software Foundation, either version 3 of the License, or (at your option)
 * any later version.
 *
 * Hell API is distributed in the hope that it will be useful, but WITHOUT ANY
 * WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
 * details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Hell API. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Controls;
using Hell.FirstCircle;

namespace HellGateMM.GUI
{
    class ContactTabItem : TabItem
    {
        private MessagingWindow window;
        private ContactTabContent tabContent;
        public Contact Contact { get; private set; }

        public ContactTabItem(MessagingWindow parentWindow, Contact contact)
        {
            window = parentWindow;
            Contact = contact;
            Header = Contact.Nickname;
            tabContent = new ContactTabContent(this, contact);
            Content = tabContent;
        }

        public void AddMessage(DateTime time, string message, bool incoming)
        {
            tabContent.Chat.Text += String.Format("\n{0} <{1}> {2}",
                time, incoming ? Contact.Nickname : "Me", message);
        }

        public void Delete()
        {
            window.MainTabControl.Items.Remove(this);
            // Close window on last tab closing:
            if (window.MainTabControl.Items.IsEmpty)
                window.Close();
        }
    }
}
