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
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

import genesys.bursify.R;
import genesys.bursify.data.entities.Sponsorship;
import genesys.bursify.data.models.SponsorshipResponse;
import genesys.bursify.utility.BursifyService;


/**
 * A simple {@link Fragment} subclass.
 */
public class SponsorshipSuggestionFragment extends Fragment
{

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private RecyclerView.LayoutManager layoutManager;

    private TextView txtSuggestionInfo;

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

        txtSuggestionInfo = (TextView) view.findViewById(R.id.txtSuggestionInfo);

        new GetSponsorshipTask().execute();

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
            sponsorships = BursifyService.getMultipleService(BursifyService.GET_SPONSORSHIP_SUGGESTIONS + 7);

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

            if(jsonArray.length() == 0)
            {
                txtSuggestionInfo.setVisibility(View.VISIBLE);
            }
            else
            {

                ArrayList<SponsorshipResponse> sponsorshipList = new ArrayList<>();

                for (int i = 0; i < jsonArray.length(); i++)
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
        }

        private SponsorshipResponse createSponsorship(JSONObject jsonObject) throws JSONException, ParseException
        {
            SponsorshipResponse s = new SponsorshipResponse(jsonObject.getInt("ID"), jsonObject.getInt("SponsorId"), jsonObject.getString("Name"), jsonObject.getString("Description"), jsonObject.getString("ClosingDate"), jsonObject.getBoolean("EssayRequired"), jsonObject.getDouble("SponsorshipValue"), jsonObject.getString("StudyFields"), jsonObject.getString("Province"), jsonObject.getInt("AverageMarkRequired"), jsonObject.getString("EducationLevel"), jsonObject.getString("InstitutionPreference"), jsonObject.getString("ExpensesCovered"), jsonObject.getString("TermsAndConditions"), jsonObject.getString("SponsorshipType"), jsonObject.getInt("Rating"));
            //sponsorshipList.add(s);
            return s;
        }
    }
}
