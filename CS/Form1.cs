﻿// Developer Express Code Central Example:
// Use only one scroll bar for a grid with multiple master/detail levels.
// 
// A grid containing a number of groups (master), each with a number of lines
// (detail) is a representation of an order which is grouped for readability. When
// a group has a greater number of lines then fits on the screen, a scrollbar is
// added to the detail-view and when there are multiple groups the master-view also
// gets a scrollbar. When the user scrolls through the grid, only the master-view
// is scrolled (unless a row is selected, then only the detail-view is scrolled)
// and it feels like the program is behaving oddly, as half the rows are
// skipped.
// To achieve this goal, we need the GridControl to have a height equal
// to the height of all content placed in a master-view. So, the scrollbar does not
// appear in either the master-view or in the detail-view. To allow scrolling, we
// need to put our GridControl into a XtraScrollableControl and set the
// GridControl.Dock property to DockStyle.Top.
// We created the MyGridControl class
// - a descendant of the GridControl. MyGridControl works with MyGridView views and
// includes the CalcGridHeight() method, which is called when the appearance of the
// Master-View is changed.
// To put MyGridControl in the XtraScrollableContainer,
// use the MyGridControl.InitScrolling() method at runtime.
// Please note that if
// you want to change Bounds or Dock properties of MyGridControl at runtime, change
// similar properties of the MyGridControl.ScrollableContainer control.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4376

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraLayout;
using System.Drawing;

namespace SingleScrollingGridControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myGridControl1.InitScrolling();
            myGridControl2.InitScrollingInLayout(layoutControlItem1);

            int master = 20; int child1 = 16;
            BindingList<MyObject> list = new BindingList<MyObject>();
            for (int i = 0; i < master; i++)
            {
                BindingList<Child> childList = new BindingList<Child>();
                for (int j = 0; j < child1; j++)
                {
                    int index = i * child1 + j;
                    Child ch = new Child(index, "Name " + index.ToString());
                    childList.Add(ch);
                }
                MyObject obj = new MyObject(i, "Name " + i.ToString(), childList);
                list.Add(obj);
            }
            myGridControl2.DataSource = list;
            myGridControl1.DataSource = list;
        }

    }
    class MyObject
    {
        private BindingList<Child> children;
        private string name;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MyObject(int i, string n, BindingList<Child> list)
        {
            id = i; name = n;
            Children = list;
        }

        public BindingList<Child> Children
        {
            get { return children; }
            set { children = value; }
        }
    }

    class Child
    {
        private string name;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Child(int i, string n)
        {
            id = i; name = n;
        }
    }
}
