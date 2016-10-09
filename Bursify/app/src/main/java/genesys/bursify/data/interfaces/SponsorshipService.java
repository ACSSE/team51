package genesys.bursify.data.interfaces;

import java.util.ArrayList;

import genesys.bursify.data.models.ApplicationResponse;
import genesys.bursify.data.models.SponsorshipResponse;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.Path;
import retrofit2.http.Query;
import retrofit2.http.Url;

/**
 * Created by Brandon on 2016/09/19.
 */
public interface SponsorshipService
{
    @GET("Sponsorship/GetAllSponsorships")
    Call<ArrayList<SponsorshipResponse>> getAllSponsorships();

    @GET("Sponsorship/GetSponsorship")
    Call<SponsorshipResponse> getSponsorship(@Query("sponsorshipId") int sponsorshipId);

    @GET("Student/GetMyApplications/?")
    Call<ResponseBody> getAllApplications(@Query("studentId") int studentId);
}
