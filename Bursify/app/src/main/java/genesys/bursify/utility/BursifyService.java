package genesys.bursify.utility;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;

/**
 * Created by Brandon on 2016/08/07.
 */
public class BursifyService
{
    private static final String API_URL = "http://bursify.azurewebsites.net/api/";

    //account api
    public static final String LOGIN = API_URL + "account/login";
    public static final String REGISTER = API_URL + "account/register";

    //student api
    public static final String GET_USER = API_URL + "bursifyuser/getuser/?email=";
    public static final String APPLY_FOR_SPONSORSHIP = API_URL + "Student/ApplyForSponsorship";
    public static final String GET_APPLICATIONS = API_URL + "Student/GetMyApplications/?studentId=";

    //sponsor api
    public static final String GET_SPONSORSHIPS = API_URL + "Sponsorship/GetAllSponsorships";
    public static final String GET_SINGLE_SPONSORSHIP = API_URL + "Sponsorship/GetSponsorship/?sponsorshipId=";

    //general implementation of http post for the web api
    public static JSONObject postService(String urlPath, JSONObject jsonPost)
    {
        JSONObject response = null;
        HttpURLConnection urlConnection = null;
        try
        {
            URL url = new URL(urlPath);
            urlConnection = (HttpURLConnection) url.openConnection();

            urlConnection.setDoInput(true);
            urlConnection.setDoOutput(true);
            urlConnection.setRequestMethod("POST");
            urlConnection.setRequestProperty("Content-Type", "application/json");
            urlConnection.setRequestProperty("Accept", "application/json");

            Writer writer = new BufferedWriter(new OutputStreamWriter(urlConnection.getOutputStream(), "UTF-8"));
            writer.write(jsonPost.toString());
            writer.flush();
            writer.close();

            BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            StringBuilder stringBuilder = new StringBuilder();
            String line;
            while ((line = bufferedReader.readLine()) != null)
            {
                stringBuilder
                        .append(line)
                        .append("\n");
            }

            bufferedReader.close();

            response = new JSONObject(stringBuilder.toString());
        }
        catch (IOException | JSONException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(urlConnection != null)
            {
                urlConnection.disconnect();
            }
        }

        return response;
    }

    //general implementation of http get for the web api
    public static JSONObject getService(String urlPath)
    {
        JSONObject response = null;
        HttpURLConnection urlConnection = null;
        try
        {
            URL url = new URL(urlPath);
            urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            StringBuilder stringBuilder = new StringBuilder();
            String line;
            while ((line = bufferedReader.readLine()) != null)
            {
                stringBuilder
                        .append(line)
                        .append("\n");
            }

            bufferedReader.close();

            response = new JSONObject(stringBuilder.toString());
        }
        catch (IOException | JSONException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(urlConnection != null)
            {
                urlConnection.disconnect();
            }
        }

        return response;
    }

    public static JSONArray getMultipleService(String urlPath)
    {
        JSONArray response = null;
        HttpURLConnection urlConnection = null;
        try
        {
            URL url = new URL(urlPath);
            urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            StringBuilder stringBuilder = new StringBuilder();
            String line;
            while ((line = bufferedReader.readLine()) != null)
            {
                stringBuilder
                        .append(line)
                        .append("\n");
            }

            bufferedReader.close();

            response = new JSONArray(stringBuilder.toString());
        }
        catch (IOException | JSONException e)
        {
            e.printStackTrace();
        }
        finally
        {
            if(urlConnection != null)
            {
                urlConnection.disconnect();
            }
        }

        return response;
    }
}
