package genesys.bursify.reportcard;


import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import genesys.bursify.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class ReportCardFragment extends Fragment
{
    public static ReportCardFragment newInstance()
    {
        ReportCardFragment reportCardFragment = new ReportCardFragment();

        Bundle args = new Bundle();

        reportCardFragment.setArguments(args);

        return reportCardFragment;
    }

    public ReportCardFragment()
    {
        // Required empty public constructor
    }
    
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_report_card, container, false);

        FloatingActionButton addReport = (FloatingActionButton) view.findViewById(R.id.btnAddReport);



        return view;
    }

}
