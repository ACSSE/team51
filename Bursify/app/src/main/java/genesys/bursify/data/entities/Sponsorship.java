package genesys.bursify.data.entities;

import java.util.Date;
import java.util.List;

public class Sponsorship
{
    private int ID;
    private int SponsorId;
    private String Name;
    private String Description;
    private Date ClosingDate;
    private boolean EssayRequired;
    private double SponsorshipValue;
    private String StudyFields;
    private String Province;
    private int AverageMarkRequired;
    private String EducationLevel;
    private String PreferredInstitutions;
    private String ExpensesCovered;
    private String TermsAndConditions;
    private String SponsorshipType;

    public Sponsorship() {}

    public Sponsorship(int ID, int sponsorId, String name, String description, Date closingDate, boolean essayRequired, double sponsorshipValue, String studyFields, String province, int averageMarkRequired, String educationLevel, String preferredInstitutions, String expensesCovered, String termsAndConditions, String sponsorshipType)
    {
        this.ID = ID;
        SponsorId = sponsorId;
        Name = name;
        Description = description;
        ClosingDate = closingDate;
        EssayRequired = essayRequired;
        SponsorshipValue = sponsorshipValue;
        StudyFields = studyFields;
        Province = province;
        AverageMarkRequired = averageMarkRequired;
        EducationLevel = educationLevel;
        PreferredInstitutions = preferredInstitutions;
        ExpensesCovered = expensesCovered;
        TermsAndConditions = termsAndConditions;
        SponsorshipType = sponsorshipType;
    }

    public int getID()
    {
        return ID;
    }

    public void setID(int ID)
    {
        this.ID = ID;
    }

    public int getSponsorId()
    {
        return SponsorId;
    }

    public void setSponsorId(int sponsorId)
    {
        SponsorId = sponsorId;
    }

    public String getName()
    {
        return Name;
    }

    public void setName(String name)
    {
        Name = name;
    }

    public String getDescription()
    {
        return Description;
    }

    public void setDescription(String description)
    {
        Description = description;
    }

    public Date getClosingDate()
    {
        return ClosingDate;
    }

    public void setClosingDate(Date closingDate)
    {
        ClosingDate = closingDate;
    }

    public boolean isEssayRequired()
    {
        return EssayRequired;
    }

    public void setEssayRequired(boolean essayRequired)
    {
        EssayRequired = essayRequired;
    }

    public double getSponsorshipValue()
    {
        return SponsorshipValue;
    }

    public void setSponsorshipValue(double sponsorshipValue)
    {
        SponsorshipValue = sponsorshipValue;
    }

    public String getStudyFields()
    {
        return StudyFields;
    }

    public void setStudyFields(String studyFields)
    {
        StudyFields = studyFields;
    }

    public String getProvince()
    {
        return Province;
    }

    public void setProvince(String province)
    {
        Province = province;
    }

    public int getAverageMarkRequired()
    {
        return AverageMarkRequired;
    }

    public void setAverageMarkRequired(int averageMarkRequired)
    {
        AverageMarkRequired = averageMarkRequired;
    }

    public String getEducationLevel()
    {
        return EducationLevel;
    }

    public void setEducationLevel(String educationLevel)
    {
        EducationLevel = educationLevel;
    }

    public String getPreferredInstitutions()
    {
        return PreferredInstitutions;
    }

    public void setPreferredInstitutions(String preferredInstitutions)
    {
        PreferredInstitutions = preferredInstitutions;
    }

    public String getExpensesCovered()
    {
        return ExpensesCovered;
    }

    public void setExpensesCovered(String expensesCovered)
    {
        ExpensesCovered = expensesCovered;
    }

    public String getTermsAndConditions()
    {
        return TermsAndConditions;
    }

    public void setTermsAndConditions(String termsAndConditions)
    {
        TermsAndConditions = termsAndConditions;
    }

    public String getSponsorshipType()
    {
        return SponsorshipType;
    }

    public void setSponsorshipType(String sponsorshipType)
    {
        SponsorshipType = sponsorshipType;
    }

}
