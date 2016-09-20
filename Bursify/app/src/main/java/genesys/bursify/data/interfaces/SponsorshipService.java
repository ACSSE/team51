package genesys.bursify.data.interfaces;

import java.util.ArrayList;

import genesys.bursify.data.models.SponsorshipResponse;
import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by Brandon on 2016/09/19.
 */
public interface SponsorshipService
{
    @GET("Sponsorship/GetAllSponsorships")
    Call<ArrayList<SponsorshipResponse>> getAllSponsorships();
}
