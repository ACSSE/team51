package genesys.bursify.data.models;

import com.google.gson.annotations.SerializedName;

import java.util.Date;

/**
 * Created by Brandon on 2016/09/19.
 */
public class SponsorshipResponse
{
    @SerializedName("ID")
    private int id;
    @SerializedName("SponsorId")
    private int sponsorId;
    @SerializedName("Name")
    private String name;
    @SerializedName("Description")
    private String description;
    @SerializedName("ClosingDate")
    private String closingDate;
    @SerializedName("EssayRequired")
    private boolean essayRequired;
    @SerializedName("SponsorshipValue")
    private double sponsorshipValue;
    @SerializedName("StudyFields")
    private String studyFields;
    @SerializedName("Province")
    private String province;
    @SerializedName("AverageMarkRequired")
    private int averageMarkRequired;
    @SerializedName("EducationLevel")
    private String educationLevel;
    @SerializedName("PreferredInstitutions")
    private String preferredInstitutions;
    @SerializedName("ExpensesCovered")
    private String expensesCovered;
    @SerializedName("TermsAndConditions")
    private String termsAndConditions;
    @SerializedName("SponsorshipType")
    private String sponsorshipType;
    @SerializedName("Rating")
    private int rating;

    public SponsorshipResponse(int id, int sponsorId, String name, String description, String closingDate, boolean essayRequired, double sponsorshipValue, String studyFields, String province, int averageMarkRequired, String educationLevel, String preferredInstitutions, String expensesCovered, String termsAndConditions, String sponsorshipType, int rating)
    {
        this.id = id;
        this.sponsorId = sponsorId;
        this.name = name;
        this.description = description;
        this.closingDate = closingDate;
        this.essayRequired = essayRequired;
        this.sponsorshipValue = sponsorshipValue;
        this.studyFields = studyFields;
        this.province = province;
        this.averageMarkRequired = averageMarkRequired;
        this.educationLevel = educationLevel;
        this.preferredInstitutions = preferredInstitutions;
        this.expensesCovered = expensesCovered;
        this.termsAndConditions = termsAndConditions;
        this.sponsorshipType = sponsorshipType;
        this.rating = rating;
    }

    public int getId()
    {
        return id;
    }

    public int getSponsorId()
    {
        return sponsorId;
    }

    public String getName()
    {
        return name;
    }

    public String getDescription()
    {
        return description;
    }

    public String getClosingDate()
    {
        return closingDate;
    }

    public boolean isEssayRequired()
    {
        return essayRequired;
    }

    public double getSponsorshipValue()
    {
        return sponsorshipValue;
    }

    public String getStudyFields()
    {
        return studyFields;
    }

    public String getProvince()
    {
        return province;
    }

    public int getAverageMarkRequired()
    {
        return averageMarkRequired;
    }

    public String getEducationLevel()
    {
        return educationLevel;
    }

    public String getPreferredInstitutions()
    {
        return preferredInstitutions;
    }

    public String getExpensesCovered()
    {
        return expensesCovered;
    }

    public String getTermsAndConditions()
    {
        return termsAndConditions;
    }

    public String getSponsorshipType()
    {
        return sponsorshipType;
    }

    public int getRating()
    {
        return rating;
    }
}
