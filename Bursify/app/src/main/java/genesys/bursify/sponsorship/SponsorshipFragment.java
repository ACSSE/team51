package genesys.bursify.sponsorship;


import android.content.res.Configuration;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.astuetz.PagerSlidingTabStrip;

import org.json.JSONArray;

import java.util.ArrayList;
import java.util.List;

import genesys.bursify.ViewPagerAdapter;
import genesys.bursify.R;
import genesys.bursify.utility.BursifyService;


/**
 * A simple {@link Fragment} subclass.
 */
public class SponsorshipFragment extends Fragment
{

    private ViewPager pager;
    private PagerSlidingTabStrip pagerTabs;

    public static SponsorshipFragment newInstance()
    {
        SponsorshipFragment sponsorshipFragment = new SponsorshipFragment();

        Bundle args = new Bundle();

        sponsorshipFragment.setArguments(args);

        return sponsorshipFragment;
    }

    public SponsorshipFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        setRetainInstance(true);
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_sponsorship, container, false);

       /* final Toolbar toolBar = (Toolbar) view.findViewById(R.id.tool_bar);
        setSupportActionBar(toolBar);*/

        pagerTabs = (PagerSlidingTabStrip) view.findViewById(R.id.tabs);

        pager = (ViewPager) view.findViewById(R.id.pager);

        ViewPagerAdapter pagerAdapter = new ViewPagerAdapter(getActivity(), getChildFragmentManager(), getFragmentViews(), getFragmentViewTitles());

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
            pagerTabs.setShouldExpand(true);
        }

        pagerTabs.setViewPager(pager);

        pagerTabs.setIndicatorColor(Color.WHITE);
        pagerTabs.setTextColor(Color.WHITE);
        pagerTabs.setVisibility(View.VISIBLE);

        return view;
    }

    private List<Fragment> getFragmentViews()
    {
        List<Fragment> viewList = new ArrayList<>();

        viewList.add(new AllSponsorshipFragment());
        viewList.add(new SponsorshipSuggestionFragment());

        return viewList;
    }

    private List<String> getFragmentViewTitles()
    {
        List<String> viewListTitles = new ArrayList<>();

        viewListTitles.add("All");
        viewListTitles.add("Recommended");

        return viewListTitles;
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
