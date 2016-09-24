package genesys.bursify.data.models;

import com.google.gson.annotations.SerializedName;

public class ApplicationResponse
{
    @SerializedName("SponsorshipId")
    private int sponsorshipId;
    @SerializedName("SponsorName")
    private String sponsorName;
    @SerializedName("SponsorshipName")
    private String sponsorshipName;
    @SerializedName("ApplicationDate")
    private String applicationDate;
    @SerializedName("ClosingDate")
    private String closingDate;
    @SerializedName("Status")
    private String status;
    @SerializedName("SponsorshipOffered")
    private boolean sponsorshipOffered;

    public int getSponsorshipId()
    {
        return sponsorshipId;
    }

    public String getSponsorName()
    {
        return sponsorName;
    }

    public String getSponsorshipName()
    {
        return sponsorshipName;
    }

    public String getApplicationDate()
    {
        return applicationDate;
    }

    public String getClosingDate()
    {
        return closingDate;
    }

    public String getStatus()
    {
        return status;
    }

    public boolean isSponsorshipOffered()
    {
        return sponsorshipOffered;
    }
}
