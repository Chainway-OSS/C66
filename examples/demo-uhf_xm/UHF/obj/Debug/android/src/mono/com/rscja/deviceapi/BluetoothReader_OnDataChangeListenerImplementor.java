package mono.com.rscja.deviceapi;


public class BluetoothReader_OnDataChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.BluetoothReader.OnDataChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_receive:([B)V:GetReceive_arrayBHandler:Com.Rscja.Deviceapi.BluetoothReader/IOnDataChangeListenerInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("Com.Rscja.Deviceapi.BluetoothReader+IOnDataChangeListenerImplementor, DeviceAPI, Version=2019.8.15.0, Culture=neutral, PublicKeyToken=null", BluetoothReader_OnDataChangeListenerImplementor.class, __md_methods);
	}


	public BluetoothReader_OnDataChangeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BluetoothReader_OnDataChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Rscja.Deviceapi.BluetoothReader+IOnDataChangeListenerImplementor, DeviceAPI, Version=2019.8.15.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void receive (byte[] p0)
	{
		n_receive (p0);
	}

	private native void n_receive (byte[] p0);

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
