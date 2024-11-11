package com.example.barcode2ds;

import android.app.ProgressDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.hardware.Camera;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.os.Message;
import android.os.Process;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.barcode.BarcodeUtility;
import com.rscja.utility.StringUtility;
import com.zebra.adc.decoder.Barcode2DWithSoft;

import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity implements View.OnClickListener,IBarcodeResult {
        Button btnScan;
        Button btnStop;
        TextView tvData;
        String TAG="MainActivity_2D";

        Barcode2D barcode2D=new Barcode2D();
        @Override
        protected void onCreate(Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_main);
            btnScan=(Button)findViewById(R.id.btnScan);
            tvData=(TextView)findViewById(R.id.tvData);
            btnStop=(Button)findViewById(R.id.btnStop);
            btnScan.setOnClickListener(this);
            btnStop.setOnClickListener(this);
            new InitTask().execute();// open();
        }

        @Override
        protected void onDestroy() {
            Log.i(TAG,"onDestroy");
            close();
            super.onDestroy();
            android.os.Process.killProcess(Process.myPid());
        }

        @Override
        public void onClick(View v) {
            switch (v.getId()){
               case  R.id.btnScan:
                   start();
                break;
                case  R.id.btnStop:
                    stop();
                break;
            }
        }

    @Override
    public void getBarcode(String barcode) {
        tvData.setText(barcode);
    }


    public class InitTask extends AsyncTask<String, Integer, Boolean> {
            ProgressDialog mypDialog;
            @Override
            protected Boolean doInBackground(String... params) {
                // TODO Auto-generated method stub
                 open();
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                return true;
            }
            @Override
            protected void onPostExecute(Boolean result) {
                super.onPostExecute(result);
                mypDialog.cancel();
            }
            @Override
            protected void onPreExecute() {
                // TODO Auto-generated method stub
                super.onPreExecute();
                mypDialog = new ProgressDialog(MainActivity.this);
                mypDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                mypDialog.setMessage("init...");
                mypDialog.setCanceledOnTouchOutside(false);
                mypDialog.setCancelable(false);
                mypDialog.show();
            }
        }

        private void start(){
            barcode2D.startScan(this);
        }
        private void stop(){
            barcode2D.stopScan(this);
        }
        private void open(){
            barcode2D.open(this,this);
        }
        private void close(){
            barcode2D.stopScan(this);
            barcode2D.close(this);
        }




}
