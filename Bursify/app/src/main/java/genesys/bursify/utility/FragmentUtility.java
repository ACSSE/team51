package genesys.bursify.utility;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;

/**
 * Created by Brandon on 2016/04/28.
 */
public class FragmentUtility
{

    public void loadFragment(Fragment fragment, String tag, int containerId, FragmentManager fragmentManager)
    {
        Fragment taggedFragment = fragmentManager.findFragmentByTag(tag);

        if (taggedFragment == null)
        {
            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            fragmentTransaction
                    .replace(containerId, fragment, tag)
                    .commit();
        }
    }
}
