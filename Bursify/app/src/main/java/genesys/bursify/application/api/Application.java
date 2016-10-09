package genesys.bursify.application.api;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ProgressBar;

import com.google.gson.Gson;
import com.google.gson.internal.LinkedTreeMap;

import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;

import genesys.bursify.application.ApplicationRecyclerViewAdapter;
import genesys.bursify.data.config.ApiClient;
import genesys.bursify.data.interfaces.SponsorshipService;
import genesys.bursify.data.models.ApplicationResponse;
import genesys.bursify.sponsorship.RecyclerViewAdapter;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by Brandon on 2016/09/24.
 */
public class Application
{
    SponsorshipService service;
    ApplicationResponse applicationResponse = null;

    public Application()
    {
        service = ApiClient.getClient().create(SponsorshipService.class);
    }

    public void getAllApplications(final RecyclerView recyclerView, final ProgressBar progressBar, int studentId)
    {
        Call<ResponseBody> responseCall = service.getAllApplications(studentId);
         responseCall.enqueue(new Callback<ResponseBody>()
        {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response)
            {
                progressBar.setVisibility(View.VISIBLE);

                int code = response.code();


                if (response.code() == 200)
                {
                    Object o = null;
                    try
                    {
                         o = new Gson().fromJson(response.body().string(), ArrayList.class);

                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                    LinkedTreeMap<String, Object> l = (LinkedTreeMap<String, Object>) o;

                    ArrayList<ApplicationResponse> li = (ArrayList<ApplicationResponse>)l.get("data");

                    //RecyclerView.Adapter adapter = new ApplicationRecyclerViewAdapter(li);
                    //recyclerView.setAdapter(adapter);
                    progressBar.setVisibility(View.GONE);

                    return;
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t)
            {
                String q = call.request().url().query();
            }
        });

    }
}
