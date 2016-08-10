package genesys.bursify.sponsorship;


import android.os.AsyncTask;
import android.os.Bundle;
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

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

import genesys.bursify.R;
import genesys.bursify.utility.BursifyService;


/**
 * A simple {@link Fragment} subclass.
 */
public class SponsorshipSuggestionFragment extends Fragment
{

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    private ProgressBar progressBar;

    private JSONArray sponsorships = null;

    public SponsorshipSuggestionFragment()
    {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_sponsorship_suggestion, container, false);

        progressBar = (ProgressBar) view.findViewById(R.id.sponsorship_recommendation_progress);
        progressBar.setVisibility(View.GONE);

        recyclerView = (RecyclerView) view.findViewById(R.id.scrollableview);
        recyclerView.setHasFixedSize(true);
        layoutManager = new LinearLayoutManager(getContext());
        recyclerView.setLayoutManager(layoutManager);


        return view;
    }

    class GetSponsorshipTask extends AsyncTask<Void, Void, JSONArray>
    {
        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected JSONArray doInBackground(Void... params)
        {
            sponsorships = BursifyService.getMultipleService(BursifyService.GET_SPOSNORSHIPS);

            return sponsorships;
        }

        @Override
        protected void onProgressUpdate(Void... values)
        {
            super.onProgressUpdate(values);
            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(JSONArray jsonArray)
        {
            super.onPostExecute(jsonArray);
            progressBar.setVisibility(View.GONE);

            ArrayList<Sponsorship> sponsorshipList = new ArrayList<>();

            for(int i = 0; i < jsonArray.length(); i++)
            {
                try
                {
                    JSONObject current = jsonArray.getJSONObject(i);

                    sponsorshipList.add(createSponsorship(current));
                }
                catch (JSONException | ParseException e)
                {
                    e.printStackTrace();
                }
            }

            adapter = new RecyclerViewAdapter(sponsorshipList);
            recyclerView.setAdapter(adapter);
        }

        private Sponsorship createSponsorship(JSONObject jsonObject) throws JSONException, ParseException
        {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd", Locale.getDefault());
            Date closingDate = sdf.parse(jsonObject.getString("ClosingDate"));

            return new Sponsorship(jsonObject.getInt("ID"), jsonObject.getInt("SponsorId"), jsonObject.getString("Name"), jsonObject.getString("Description"), closingDate, jsonObject.getBoolean("EssayRequired"), jsonObject.getDouble("SponsorshipValue"), jsonObject.getString("StudyFields"), jsonObject.getString("Province"), jsonObject.getInt("AverageMarkRequired"), jsonObject.getString("EducationLevel"), jsonObject.getString("PreferredInstitutions"), jsonObject.getString("ExpensesCovered"), jsonObject.getString("TermsAndConditions"), jsonObject.getString("SponsorshipType"));
        }
    }
}
