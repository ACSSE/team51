package genesys.bursify.sponsorship;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import genesys.bursify.R;


/**
 * A simple {@link Fragment} subclass.
 */
public class LearnershipFragment extends Fragment
{

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    public LearnershipFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_learnership, container, false);

        recyclerView = (RecyclerView) view.findViewById(R.id.scrollableview);
        recyclerView.setHasFixedSize(true);
        layoutManager = new LinearLayoutManager(getContext());
        recyclerView.setLayoutManager(layoutManager);

        //adapter = new RecyclerViewAdapter();
        recyclerView.setAdapter(adapter);

        return view;
    }

}
