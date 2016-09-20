package genesys.bursify.data.config;

import android.app.Application;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class ApiClient extends Application
{
    private static Retrofit retrofit;

    public static Retrofit getClient()
    {
        String baseUrl = "http://bursify.azurewebsites.net/api/";

        if(retrofit == null)
        {
            retrofit = new Retrofit.Builder()
                    .baseUrl(baseUrl)
                    .addConverterFactory(GsonConverterFactory.create())
                    .build();
        }

        return retrofit;
    }
}
