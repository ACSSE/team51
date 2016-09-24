package genesys.bursify.application;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import genesys.bursify.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class ApplicationFragment extends Fragment
{
    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    public static ApplicationFragment newInstance()
    {
        ApplicationFragment applicationFragment = new ApplicationFragment();

        Bundle args = new Bundle();

        applicationFragment.setArguments(args);

        return applicationFragment;
    }

    public ApplicationFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_application, container, false);
    }

}
