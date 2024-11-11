package com.example.hometest;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity {

	Button btnMenuY;
	Button btnMenuN;
	Button btnHomeY;
	Button btnHomeN;
	Button btndownY;
	Button btndownN;
	Button btntouchY;
	Button btntouchN;
	Button btnscreenY;
	Button btnscreenN;
	Button btnscapY;
	Button btnscapN;
	
	TextView tv;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		HomeKeyEventBroadCastReceiver receiver = new HomeKeyEventBroadCastReceiver();
		registerReceiver(receiver, new IntentFilter(
				"com.rscja.android.KEY_DOWN"));

		InitView();
	}

	void InitView() {
		tv = (TextView) findViewById(R.id.textView4);
		btnMenuY = (Button) findViewById(R.id.btnmenuyes);
		btnMenuN = (Button) findViewById(R.id.btnmenuno);
		btnHomeY = (Button) findViewById(R.id.btnhomeyes);
		btnHomeN = (Button) findViewById(R.id.btnhomeno);
		btndownY = (Button) findViewById(R.id.btndownyes);
		btndownN = (Button) findViewById(R.id.btndownno);
		btntouchY = (Button) findViewById(R.id.btntouchY);
		btntouchN = (Button) findViewById(R.id.btntouchN);
		btnscreenY=(Button)findViewById(R.id.btnscreenY);
		btnscreenN=(Button)findViewById(R.id.btnscreenN);
		btnscapY=(Button)findViewById(R.id.btnscapY);
		btnscapN=(Button)findViewById(R.id.btnscapN);
		
		btnMenuY.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent("android.intent.action.MENU_ENABLE");
				sendBroadcast(intent);
			}
		});

		btnMenuN.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.MENU_DISABLED");
				sendBroadcast(intent);
			}
		});

		btnHomeY.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent("android.intent.action.HOME_ENABLE");
				sendBroadcast(intent);
			}
		});

		btnHomeN.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.HOME_DISABLED");
				sendBroadcast(intent);
			}
		});

		btndownY.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent("android.intent.action.PANEL_ENABLE");
				sendBroadcast(intent);
			}
		});

		btndownN.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.PANEL_DISABLED");
				sendBroadcast(intent);
			}
		});
		
		btntouchY.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.TOUCH_ENABLE");
				sendBroadcast(intent);
			}
		});
		
		btntouchN.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.TOUCH_DISABLED");
				sendBroadcast(intent);
			}
		});

		btnscreenY.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.UnLock");
				sendBroadcast(intent);
			}
		});
		
		btnscreenN.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.Lock");
				sendBroadcast(intent);
			}
		});
		
		btnscapY.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.SCAP_ENABLE");
				sendBroadcast(intent);
			}
		});
		
		btnscapN.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(
						"android.intent.action.SCAP_DISABLED");
				sendBroadcast(intent);
			}
		});
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {

		tv.setText(String.valueOf(keyCode));
		if(keyCode==139)
		{
			Intent intent = new Intent(
					"android.intent.action.TOUCH_ENABLE");
			sendBroadcast(intent);
			
		}
		return super.onKeyDown(keyCode, event);

	}

}

/*
 * 禁用功能后，此类监控真实键值，keydown事件不反映
 * 
 * After disable this function, the real key value of this class,keydown event
 * will not response.
 */

class HomeKeyEventBroadCastReceiver extends BroadcastReceiver {

	static final String SYSTEM_REASON = "reason";
	static final String SYSTEM_HOME_KEY = "homekey";// home key
	static final String SYSTEM_RECENT_APPS = "recentapps";// long home key

	@Override
	public void onReceive(Context context, Intent intent) {
		String action = intent.getAction();
		if (action.equals("com.rscja.android.KEY_DOWN")) {
			int reason = intent.getIntExtra("Keycode", 0);
			// getStringExtra
			boolean long1 = intent.getBooleanExtra("Pressed", false);

			// home key处理点
			Toast.makeText(
					context.getApplicationContext(),
					"home key=" + reason + ",long1="
							+ ((long1 == false) ? "Short Press" : "Long Press"),
					Toast.LENGTH_SHORT).show();
		}
	}

}
