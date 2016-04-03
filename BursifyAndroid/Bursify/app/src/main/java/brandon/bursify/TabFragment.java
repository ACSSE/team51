package brandon.bursify;


import android.content.res.Configuration;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.astuetz.PagerSlidingTabStrip;


/**
 * A simple {@link Fragment} subclass.
 */
public class TabFragment extends Fragment
{

    private ViewPager pager;
    private PagerSlidingTabStrip pagerTabs;

    public static TabFragment newInstance()
    {
        TabFragment tabFragment = new TabFragment();

        Bundle args = new Bundle();

        tabFragment.setArguments(args);

        return tabFragment;
    }

    public TabFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        setRetainInstance(true);
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_tab, container, false);

       /* final Toolbar toolBar = (Toolbar) view.findViewById(R.id.tool_bar);
        setSupportActionBar(toolBar);*/

        pagerTabs = (PagerSlidingTabStrip) view.findViewById(R.id.tabs);

        pager = (ViewPager) view.findViewById(R.id.pager);

        HomeViewPagerAdapter pagerAdapter = new HomeViewPagerAdapter(getActivity(), getChildFragmentManager());

        pager.setAdapter(pagerAdapter);

        int screenSize = (getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK);

        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
        {
            pagerTabs.setShouldExpand(true);
        }
        else if (screenSize == Configuration.SCREENLAYOUT_SIZE_XLARGE)
        {
            pagerTabs.setShouldExpand(true);

        }
        else
        {
            pagerTabs.setShouldExpand(false);
        }

        pagerTabs.setViewPager(pager);

        pagerTabs.setIndicatorColor(Color.BLACK);
        pagerTabs.setTextColor(Color.WHITE);
        pagerTabs.setVisibility(View.VISIBLE);

        return view;
    }

    @Override
    public void onDetach()
    {
        super.onDetach();
        setHasOptionsMenu(false);
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        setHasOptionsMenu(false);
    }

}
