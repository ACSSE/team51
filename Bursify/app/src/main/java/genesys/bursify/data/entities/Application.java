package genesys.bursify.data.entities;

/**
 * Created by Brandon on 2016/10/08.
 */
public class Application
{
    private int sponsorshipId;
    private String sponsorName;
    private String sponsorshipName;
    private String applicationDate;
    private String closingDate;
    private String status;
    private boolean sponsorshipOffered;

    public Application(int sponsorshipId, String sponsorName, String sponsorshipName, String applicationDate, String closingDate, String status, boolean sponsorshipOffered)
    {
        this.sponsorshipId = sponsorshipId;
        this.sponsorName = sponsorName;
        this.sponsorshipName = sponsorshipName;
        this.applicationDate = applicationDate;
        this.closingDate = closingDate;
        this.status = status;
        this.sponsorshipOffered = sponsorshipOffered;
    }

    public int getSponsorshipId()
    {
        return sponsorshipId;
    }

    public void setSponsorshipId(int sponsorshipId)
    {
        this.sponsorshipId = sponsorshipId;
    }

    public String getSponsorName()
    {
        return sponsorName;
    }

    public void setSponsorName(String sponsorName)
    {
        this.sponsorName = sponsorName;
    }

    public String getSponsorshipName()
    {
        return sponsorshipName;
    }

    public void setSponsorshipName(String sponsorshipName)
    {
        this.sponsorshipName = sponsorshipName;
    }

    public String getApplicationDate()
    {
        return applicationDate;
    }

    public void setApplicationDate(String applicationDate)
    {
        this.applicationDate = applicationDate;
    }

    public String getClosingDate()
    {
        return closingDate;
    }

    public void setClosingDate(String closingDate)
    {
        this.closingDate = closingDate;
    }

    public String getStatus()
    {
        return status;
    }

    public void setStatus(String status)
    {
        this.status = status;
    }

    public boolean isSponsorshipOffered()
    {
        return sponsorshipOffered;
    }

    public void setSponsorshipOffered(boolean sponsorshipOffered)
    {
        this.sponsorshipOffered = sponsorshipOffered;
    }
}
