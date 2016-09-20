package genesys.bursify.utility;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

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

    public static int calculateDaysBetween(Date endDate, Date startDate)
    {
        int dayCount = (int)((endDate.getTime() - startDate.getTime())/(1000*60*60*24));

        if(dayCount < 0)
        {
            dayCount *= -1;
        }

        return dayCount;
    }

    public static Date getDateFrom(String dateString)
    {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd", Locale.getDefault());
        String rawDate = dateString.substring(0, 10).replaceAll("-", "/");

        Date date = null;
        try
        {
            date = sdf.parse(rawDate);
        }
        catch (ParseException e)
        {
            e.printStackTrace();
        }

        return date;
    }

    public static String createDate(String date)
    {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd", Locale.getDefault());
        String rawDate = date.substring(0, 10).replaceAll("-", "/");

        Date closingDate = null;
        try
        {
            closingDate = sdf.parse(rawDate);
        }
        catch (ParseException e)
        {
            e.printStackTrace();
        }

        return (new SimpleDateFormat("MMMM dd, yyyy").format(closingDate));
    }
}
