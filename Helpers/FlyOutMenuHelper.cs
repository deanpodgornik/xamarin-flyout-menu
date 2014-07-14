using Android.App;
using Android.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Widget;
using NavDrawer.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavDrawer.Helpers
{
    class FlyOutMenuHelper
    {

        public static DrawerLayout m_Drawer;
        public static ListView m_DrawerList;
        public static MyActionBarDrawerToggle m_DrawerToggle;
        public static string m_DrawerTitle;
        public static string m_Title;
        private static readonly string[] Sections = new[]{
            "Activity 1", "Activity 2"
        };
        public static void drawerIni(ActionBarActivity context)
        {
            FlyOutMenuHelper.m_Drawer = context.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            m_DrawerList = context.FindViewById<ListView>(Resource.Id.flyOutMenu);
            m_DrawerList.Adapter = new ArrayAdapter<string>(context, Resource.Layout.flyOutMenuItem_view, Sections);
            //list item click event
            FlyOutMenuHelper.m_DrawerList.ItemClick += (sender, args) => ListItemClicked(args.Position, context);
            FlyOutMenuHelper.m_Drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityCompat.Start);
            //DrawerToggle is the animation that happens with the indicator next to the actionbar
            FlyOutMenuHelper.m_DrawerToggle = new MyActionBarDrawerToggle(context, m_Drawer,
													  Resource.Drawable.ic_drawer_dark,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);
            //Display the current fragments title and update the options menu
            m_DrawerToggle.DrawerClosed += (o, args) => {
				/*
                SupportActionBar.Title = m_Title;
				SupportInvalidateOptionsMenu();
                */
            };
            //Display the drawer title and update the options menu
            m_DrawerToggle.DrawerOpened += (o, args) => 
            {
                /*
				this.SupportActionBar.Title = this.m_DrawerTitle;
				this.SupportInvalidateOptionsMenu();
                */
            };
            //Set the drawer lister to be the toggle.
            m_Drawer.SetDrawerListener(m_DrawerToggle);
        }

        private static void ListItemClicked(int position, ActionBarActivity context)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                case 0:
                    context.StartActivity(typeof(Activity1));
                    FlyOutMenuHelper.m_Drawer.CloseDrawer(FlyOutMenuHelper.m_DrawerList);
                    break;
                case 1:
                    context.StartActivity(typeof(Activity2));
                    FlyOutMenuHelper.m_Drawer.CloseDrawer(FlyOutMenuHelper.m_DrawerList);
                    /*
                    fragment = new ProfileFragment();
                    context.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
                    Global.m_DrawerList.SetItemChecked(position, true);
                    context.SupportActionBar.Title = Global.m_Title = Sections[position];
                    Global.m_Drawer.CloseDrawer(Global.m_DrawerList);
                    */
                    break;
            }
        }
    }
}
