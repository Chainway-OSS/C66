package mono.com.zebra.adc.decoder;


public class BarCodeReader_OnZoomChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.zebra.adc.decoder.BarCodeReader.OnZoomChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onZoomChange:(IZLcom/zebra/adc/decoder/BarCodeReader;)V:GetOnZoomChange_IZLcom_zebra_adc_decoder_BarCodeReader_Handler:Com.Zebra.Adc.Decoder.BarCodeReader/IOnZoomChangeListenerInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("Com.Zebra.Adc.Decoder.BarCodeReader+IOnZoomChangeListenerImplementor, DeviceAPI, Version=2019.8.15.0, Culture=neutral, PublicKeyToken=null", BarCodeReader_OnZoomChangeListenerImplementor.class, __md_methods);
	}


	public BarCodeReader_OnZoomChangeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BarCodeReader_OnZoomChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Zebra.Adc.Decoder.BarCodeReader+IOnZoomChangeListenerImplementor, DeviceAPI, Version=2019.8.15.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onZoomChange (int p0, boolean p1, com.zebra.adc.decoder.BarCodeReader p2)
	{
		n_onZoomChange (p0, p1, p2);
	}

	private native void n_onZoomChange (int p0, boolean p1, com.zebra.adc.decoder.BarCodeReader p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
