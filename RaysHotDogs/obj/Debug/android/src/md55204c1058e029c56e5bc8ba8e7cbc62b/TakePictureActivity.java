package md55204c1058e029c56e5bc8ba8e7cbc62b;


public class TakePictureActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RaysHotDogs.TakePictureActivity, RaysHotDogs", TakePictureActivity.class, __md_methods);
	}


	public TakePictureActivity ()
	{
		super ();
		if (getClass () == TakePictureActivity.class)
			mono.android.TypeManager.Activate ("RaysHotDogs.TakePictureActivity, RaysHotDogs", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
