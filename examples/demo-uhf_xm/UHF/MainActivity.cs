﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Rscja.Deviceapi; 
using System.Collections; 
using System.Collections.Generic;
using Android.Util;

namespace UHF
{
	[Activity (Label = "UHF", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public RFIDWithUHF uhfAPI;
		private ActionBar actionBar=null;
		private Scan_Fragment scan_Fragment=null;
		private Set_Fragment set_Fragment=null;
		private Write_Fragment write_Fragment =null;
		private Read_Fragment read_Fragment =null;
        HomeKeyEventBroadCastReceiver receiver;
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			 
			 if (uhfAPI == null) {
				try
				{
					 uhfAPI=RFIDWithUHF.Instance;
				 	 uhfAPI.StopInventory ();
				}catch
				{
				
				}
			 }

            Log.Debug("DeviceAPI_",VersionInfo.Version+"--sssssss");

            initTab ();


            //receiver = new HomeKeyEventBroadCastReceiver(scan_Fragment);
            //RegisterReceiver(receiver, new IntentFilter("com.rscja.android.KEY_DOWN"));
        }

		protected override void OnResume()
		{
			base.OnResume ();
            Log.Info("re2",uhfAPI.ToString());
            if (uhfAPI != null) {
               
				new InitTask (this).Execute ();
			}
		}
		protected override void  OnPause()
		{
			base.OnPause ();
		}

        protected override void OnDestroy()
        {

            base.OnDestroy();
            uhfAPI.Free();
        }

        public override bool OnKeyDown(Keycode keyCode,KeyEvent e)
		{
           
			if (e.KeyCode.GetHashCode() == 139 || e.KeyCode.GetHashCode() == 280 || e.KeyCode.GetHashCode() == 293) {
				if (e.RepeatCount == 0) {
					if (actionBar.SelectedTab.Tag != null) {
						//if (actionBar.SelectedTab.Tag.ToString() == "Scan") {
							scan_Fragment.scan ();
                           
							return true;
						//}
					}
				}
			}
			return base.OnKeyDown (keyCode, e);


		}
		void initTab()
		{
			scan_Fragment = new Scan_Fragment ();
			set_Fragment = new Set_Fragment ();
			write_Fragment = new Write_Fragment ();
			read_Fragment = new Read_Fragment ();

			actionBar = ActionBar;
			actionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			actionBar.SetDisplayHomeAsUpEnabled (true);

			ActionBar.Tab tab1 = actionBar.NewTab ();
			tab1.SetTag("Scan");
			tab1.SetText(Resource.String.tab_Scan);
			tab1.TabSelected += (object sender, ActionBar.TabEventArgs e) => {
				e.FragmentTransaction.Replace(Android.Resource.Id.Content,scan_Fragment);
			};   

			ActionBar.Tab tab2 = actionBar.NewTab ();
			tab1.SetTag ("Write");
			tab2.SetText (Resource.String.tab_WriteData);
			tab2.TabSelected += (object sender, ActionBar.TabEventArgs e) => {
				e.FragmentTransaction.Replace(Android.Resource.Id.Content,write_Fragment);
			};
			ActionBar.Tab tab3 = actionBar.NewTab ();
			tab1.SetTag ("Read");
			tab3.SetText (Resource.String.tab_ReadData);
			tab3.TabSelected += (object sender, ActionBar.TabEventArgs e) => {
				e.FragmentTransaction.Replace(Android.Resource.Id.Content,read_Fragment);
			};

			ActionBar.Tab tab4 = actionBar.NewTab ();
			tab1.SetTag ("Config");
			tab4.SetText (Resource.String.tab_set);
			tab4.TabSelected += (object sender, ActionBar.TabEventArgs e) => {
				e.FragmentTransaction.Replace(Android.Resource.Id.Content,set_Fragment);
			};
			actionBar.AddTab (tab1);
			actionBar.AddTab (tab2);
			actionBar.AddTab (tab3);
			actionBar.AddTab (tab4);
		}

		private class InitTask: AsyncTask<Java.Lang.Void, Java.Lang.Void, string[]>{

			MainActivity mainActivity;
			ProgressDialog  proDialg=null;

			public InitTask(MainActivity _mainActivity)
			{
				mainActivity=_mainActivity;
			}
			protected override string[] RunInBackground (params Java.Lang.Void[] @params)
			{
				//throw new NotImplementedException ();
				return null;
			}

			//后台要执行的任务
			protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
			{
				string result ="No";
				if  (mainActivity.uhfAPI!=null)  
				{
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i != 3)
                        {
                            if (!mainActivity.uhfAPI.Init())
                                mainActivity.uhfAPI.Free();
                            else
                             return "OK";
                            
                        }
                        else
                        {
                            if (mainActivity.uhfAPI.Init())
                            {
                                result = "OK";
                            }
                        }
                       
                    
                    }
					
				}
				return result;
			}
			protected override void OnPostExecute(Java.Lang.Object result)
			{
				proDialg.Cancel();
                Log.Debug("结果", result.ToString());
				if (result.ToString() != "OK")
					Toast.MakeText (mainActivity,"Init failure!",ToastLength.Short);
			}

			//开始执行任务
			protected override void OnPreExecute()
			{
				proDialg=new ProgressDialog(mainActivity);
				proDialg.SetMessage("init.....");
				proDialg.Show();
			}
		}


	}


    class HomeKeyEventBroadCastReceiver : BroadcastReceiver
    {

        String SYSTEM_REASON = "reason";
        String SYSTEM_HOME_KEY = "homekey";//home key
        String SYSTEM_RECENT_APPS = "recentapps";//long home key
        Scan_Fragment scan;


        public HomeKeyEventBroadCastReceiver(Scan_Fragment scan_Fragment)
        {
            scan = scan_Fragment;
        }
        public override void OnReceive(Context context, Intent intent)
        {

            String action = intent.Action;// getAction();
            if (action.Equals("com.rscja.android.KEY_DOWN"))
            {
                int reason = intent.GetIntExtra("keycode", 0);
                if (reason == 0)
                    reason = intent.GetIntExtra("Keycode", 0);

                //getStringExtra
                bool long1 = intent.GetBooleanExtra("Pressed", false);
                // home key处理点
                // Toast.makeText(getApplicationContext(), "home key=" + reason + ",long1=" + long1, Toast.LENGTH_SHORT).show();
                if (reason == 139 || reason == 280)
                {

                    scan.scan();


                }
            }
        }
    }
}


