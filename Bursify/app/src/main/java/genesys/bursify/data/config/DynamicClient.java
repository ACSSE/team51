package genesys.bursify.data.config;

import java.io.IOException;

import retrofit2.Converter;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by Brandon on 2016/10/07.
 */
public class DynamicClient<T>
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
