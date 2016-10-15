package genesys.bursify.sponsorship.api;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ProgressBar;

import java.util.ArrayList;

import genesys.bursify.data.config.ApiClient;
import genesys.bursify.data.interfaces.SponsorshipService;
import genesys.bursify.data.models.ApplicationResponse;
import genesys.bursify.data.models.SponsorshipResponse;
import genesys.bursify.sponsorship.RecyclerViewAdapter;
import genesys.bursify.sponsorship.ViewSponsorshipActivity;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Sponsorship
{
    SponsorshipService service;
    SponsorshipResponse sponsorshipResponse = null;

    public Sponsorship()
    {
        service = ApiClient.getClient().create(SponsorshipService.class);
    }

    public SponsorshipResponse getSponsorship(final int sponsorshipId)
    {

        Call<SponsorshipResponse> responseCall = service.getSponsorship(sponsorshipId);
        responseCall.enqueue(new Callback<SponsorshipResponse>()
        {
            @Override
            public void onResponse(Call<SponsorshipResponse> call, Response<SponsorshipResponse> response)
            {
                if(response.code() == 200)
                {
                    sponsorshipResponse = response.body();
                }
            }

            @Override
            public void onFailure(Call<SponsorshipResponse> call, Throwable t)
            {

            }
        });

        return sponsorshipResponse;
    }

    public void getAllSponsorships(final RecyclerView recyclerView, final ProgressBar progressBar)
    {
        Call<ArrayList<SponsorshipResponse>> responseCall = service.getAllSponsorships();
        responseCall.enqueue(new Callback<ArrayList<SponsorshipResponse>>()
        {
            @Override
            public void onResponse(Call<ArrayList<SponsorshipResponse>> call, Response<ArrayList<SponsorshipResponse>> response)
            {
                progressBar.setVisibility(View.VISIBLE);

                if (response.code() == 200)
                {
                    RecyclerView.Adapter adapter = new RecyclerViewAdapter(response.body());
                    recyclerView.setAdapter(adapter);
                    progressBar.setVisibility(View.GONE);

                    return;
                }
            }

            @Override
            public void onFailure(Call<ArrayList<SponsorshipResponse>> call, Throwable t)
            {

            }
        });

    }

    public void getSponsorshipSuggestions(final RecyclerView recyclerView, final ProgressBar progressBar)
    {
        Call<ArrayList<SponsorshipResponse>> responseCall = service.getAllSponsorships();
        responseCall.enqueue(new Callback<ArrayList<SponsorshipResponse>>()
        {
            @Override
            public void onResponse(Call<ArrayList<SponsorshipResponse>> call, Response<ArrayList<SponsorshipResponse>> response)
            {
                progressBar.setVisibility(View.VISIBLE);

                if (response.code() == 200)
                {
                    RecyclerView.Adapter adapter = new RecyclerViewAdapter(response.body());
                    recyclerView.setAdapter(adapter);
                    progressBar.setVisibility(View.GONE);

                    return;
                }
            }

            @Override
            public void onFailure(Call<ArrayList<SponsorshipResponse>> call, Throwable t)
            {

            }
        });

    }
}
