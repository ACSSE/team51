package genesys.bursify.data.entities;

import java.util.Date;

/**
 * Created by Brandon on 2016/09/17.
 */
public class Student
{
    private int ID;
    private String Name;
    private String Email;
    private String AccountStatus;
    private String UserType;
    private Date RegistrationDate;
    private String Biography;
    private String CellphoneNumber;
    private String TelephoneNumber;
    private String ProfilePicturePath;

    public Student(int ID, String name, String email, String accountStatus, String userType, Date registrationDate, String biography, String cellphoneNumber, String telephoneNumber, String profilePicturePath)
    {
        this.ID = ID;
        Name = name;
        Email = email;
        AccountStatus = accountStatus;
        UserType = userType;
        RegistrationDate = registrationDate;
        Biography = biography;
        CellphoneNumber = cellphoneNumber;
        TelephoneNumber = telephoneNumber;
        ProfilePicturePath = profilePicturePath;
    }

    public int getID()
    {
        return ID;
    }

    public void setID(int ID)
    {
        this.ID = ID;
    }

    public String getName()
    {
        return Name;
    }

    public void setName(String name)
    {
        Name = name;
    }

    public String getEmail()
    {
        return Email;
    }

    public void setEmail(String email)
    {
        Email = email;
    }

    public String getAccountStatus()
    {
        return AccountStatus;
    }

    public void setAccountStatus(String accountStatus)
    {
        AccountStatus = accountStatus;
    }

    public String getUserType()
    {
        return UserType;
    }

    public void setUserType(String userType)
    {
        UserType = userType;
    }

    public Date getRegistrationDate()
    {
        return RegistrationDate;
    }

    public void setRegistrationDate(Date registrationDate)
    {
        RegistrationDate = registrationDate;
    }

    public String getBiography()
    {
        return Biography;
    }

    public void setBiography(String biography)
    {
        Biography = biography;
    }

    public String getCellphoneNumber()
    {
        return CellphoneNumber;
    }

    public void setCellphoneNumber(String cellphoneNumber)
    {
        CellphoneNumber = cellphoneNumber;
    }

    public String getTelephoneNumber()
    {
        return TelephoneNumber;
    }

    public void setTelephoneNumber(String telephoneNumber)
    {
        TelephoneNumber = telephoneNumber;
    }

    public String getProfilePicturePath()
    {
        return ProfilePicturePath;
    }

    public void setProfilePicturePath(String profilePicturePath)
    {
        ProfilePicturePath = profilePicturePath;
    }
}
