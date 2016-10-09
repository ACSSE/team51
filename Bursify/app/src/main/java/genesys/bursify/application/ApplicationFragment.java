package genesys.bursify.application;


import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import genesys.bursify.R;
import genesys.bursify.data.entities.Application;
import genesys.bursify.utility.BursifyService;

/**
 * A simple {@link Fragment} subclass.
 */
public class ApplicationFragment extends Fragment
{
    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    private ProgressBar progressBar;

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
        View view = inflater.inflate(R.layout.fragment_application, container, false);

        progressBar = (ProgressBar) view.findViewById(R.id.application_progress);

        recyclerView = (RecyclerView) view.findViewById(R.id.applicationList);
        recyclerView.setHasFixedSize(true);
        layoutManager = new LinearLayoutManager(getContext());
        recyclerView.setLayoutManager(layoutManager);

        //adapter = new ApplicationRecyclerViewAdapter();
        //recyclerView.setAdapter(adapter);

        new GetApplicationTask().execute();
        //Application application = new Application();

        //application.getAllApplications(recyclerView, progressBar, userId);

        return view;
    }

    class GetApplicationTask extends AsyncTask<Void, Void, JSONObject>
    {
        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();

            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected JSONObject doInBackground(Void... params)
        {
            SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(getContext());
            final int userId = preferences.getInt("userId", 0);

            JSONObject response;

            response = BursifyService.getService(BursifyService.GET_APPLICATIONS + 7);

            return response;
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);

            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(JSONObject jsonObject)
        {
            super.onPostExecute(jsonObject);

            ArrayList<Application> applications = new ArrayList<>();

            try
            {
                JSONArray jsonArray = jsonObject.getJSONArray("data");

                for(int i = 0; i < jsonArray.length(); i++)
                {
                    Application app = new Application(jsonArray.getJSONObject(i).getInt("SponsorshipId"), jsonArray.getJSONObject(i).getString("SponsorName"), jsonArray.getJSONObject(i).getString("SponsorshipName"), jsonArray.getJSONObject(i).getString("ApplicationDate"), jsonArray.getJSONObject(i).getString("ClosingDate"), jsonArray.getJSONObject(i).getString("Status"), jsonArray.getJSONObject(i).getBoolean("SponsorshipOffered"));

                    applications.add(app);
                }

                adapter = new ApplicationRecyclerViewAdapter(applications);
                recyclerView.setAdapter(adapter);
            }
            catch (JSONException e)
            {
                e.printStackTrace();
            }

            progressBar.setVisibility(View.GONE);
        }
    }
}
