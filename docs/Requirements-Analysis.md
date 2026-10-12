# DVLD --- Driving License Management System

## Requirements Specification

**Project:** DVLD Project 1 --- Driving License Management\
**Source:** *DVLD: Project 1 -- Driving License Management*\
**Document purpose:** Organize the requirements from the source PDF into
a clear English Markdown specification.

------------------------------------------------------------------------

## 1. System Overview

The Driving and Vehicle License Department (DVLD) system manages people,
system users, service applications, driving-license classes, tests, and
issued licenses.

The system must retain each person's information without duplicating the
same person. A person may submit multiple applications and may hold
licenses from different classes.

## 2. People Management

The system shall allow authorized users to manage people.

### 2.1 Required operations

-   Search for a person by national number.
-   View a person's information.
-   Add a new person.
-   Edit a person's information.
-   Delete a person.
-   Prevent duplicate people with the same national number.

### 2.2 Person information

Each person record shall contain:

-   National number
-   Four-part full name
-   Date of birth
-   Address
-   Phone number
-   Email address
-   Nationality
-   Personal photograph

### 2.3 Person-related rules

-   A person's information must be stored once and reused throughout the
    system.
-   Before creating a service application, the system must identify the
    applicant by national number.
-   If the person does not already exist, the user must add the person
    before proceeding with the application.
-   A person may have more than one application.
-   Once a license is issued to a person, that person becomes a
    registered driver in the system. The driver is assigned a driver
    number once, and future licenses are linked to that driver.

## 3. User Management

The system shall provide functionality to manage system users.

### 3.1 Required operations

-   Add a user by linking the user account to an existing person.
-   View user information.
-   Edit user information.
-   Delete a user.
-   Freeze/deactivate a user account.
-   Assign permissions to users.

### 3.2 User information

A user account is associated with a person and includes the person's
information:

-   National number
-   Four-part full name
-   Date of birth
-   Address
-   Phone number
-   Email address
-   Nationality
-   Personal photograph

It also includes:

-   Username
-   Password

## 4. Service Applications

An applicant must submit an application for the required service and pay
the applicable application fee.

### 4.1 Application information

Each application shall include:

-   Application number
-   Application date
-   Applicant/person number
-   Application type/service
-   Application status: `New`, `Cancelled`, or `Completed`
-   Application fee paid

### 4.2 Application rules

-   Every application must be linked to one person.
-   A person may have multiple applications.
-   The system must prevent an applicant from having another unfinished
    application of the same type.
-   For a first-time driving-license application, the requested license
    class must be recorded.
-   The applicant must not already hold a license in the same class.
-   The system must validate the applicant's eligibility before allowing
    the application to proceed.

### 4.3 Application management operations

The system shall allow users to:

-   Search for an application by application number.
-   Search for applications using a person's national number.
-   View a list of applications.
-   View application details, including application fees.
-   Edit application information.
-   Filter applications by status.

## 5. Driving-License Classes

The system contains seven predefined driving-license classes. The system
shall allow the configured minimum age, validity period, and class fee
to be changed.

### 5.1 License-class information

Each license class shall include:

-   `LicenseClassID`
-   `ClassName`
-   `ClassDescription`
-   `MinimumAllowedAge`
-   `ValidityLength` --- number of years the license remains valid
-   `ClassFees`

### 5.2 Defined license classes

  ------------------------------------------------------------------------------
  Class       Description /          Minimum age     License fee        Validity
              permitted vehicles                                 
  ----------- ------------------ --------------- --------------- ---------------
  1           Small motorcycles               18            \$15         5 years

  2           Heavy/large                     21            \$30         5 years
              motorcycles                                        

  3           Ordinary driving                18            \$20        10 years
              license for cars                                   
              and light vehicles                                 

  4           Commercial driving              21           \$200        10 years
              license for                                        
              taxis/limousines                                   

  5           Agricultural                    21            \$50        10 years
              vehicles,                                          
              tractors, and                                      
              plowing machinery                                  

  6           Small and                       21           \$250        10 years
              medium-sized buses                                 

  7           Trucks and heavy                21           \$300        10 years
              vehicles,                                          
              including large                                    
              buses and trucks                                   
  ------------------------------------------------------------------------------

### 5.3 Eligibility rules

For a first-time license application:

-   The applicant must meet the minimum age for the selected class.
    Otherwise, the system must reject the application.
-   The applicant must not already hold a license of the same class.
    Otherwise, the system must reject the application.
-   A person may hold licenses from more than one class, such as an
    ordinary vehicle license and a motorcycle license.
-   The applicant must provide valid personal identification documents,
    such as a passport or national identity card.
-   The applicant must provide proof of completing the required
    vehicle-driving training courses before being eligible to take the
    tests.

## 6. Tests and Test Appointments

A first-time license applicant must pass all three tests in the
following order:

1.  Eyesight test
2.  Theoretical test
3.  Practical driving test

Each test must be paid for before it is taken. Test fees depend on the
applied-for license class, as described in the source requirements.

### 6.1 Eyesight test

-   The system shall allow an eyesight-test appointment to be scheduled.
-   The applicant must pay the test fee before taking the test.
-   The system shall record the test date and result (`Passed` or
    `Failed`).
-   Test fee stated in the source: **\$10**.
-   If the applicant fails, the system must not allow the licensing
    process to continue until the eyesight issue has been addressed and
    another eyesight-test appointment has been scheduled.

### 6.2 Theoretical test

-   The theoretical test may be scheduled only after the applicant
    passes the eyesight test.
-   The appointment is scheduled manually by a system user.
-   The applicant answers questions about traffic laws and driving
    safety.
-   The examination is conducted on paper outside the system.
-   The system shall record whether the applicant passed or failed and
    the score out of 100.
-   Test fee stated in the source: **\$20**.
-   If the applicant fails, another appointment may be scheduled after
    the test fee is paid again.

### 6.3 Practical driving test

-   The practical test may be scheduled only after the applicant passes
    the preceding test.
-   The appointment is scheduled manually by a system user.
-   The test evaluates the applicant's ability to control the vehicle
    and follow traffic rules.
-   The test fee must be paid before the test.
-   If the applicant fails, another appointment may be scheduled after
    the fee is paid again.

### 6.4 Test management

-   Test types are fixed in the system; users may modify their fees
    only.
-   Each test appointment must be associated with the relevant
    application and test.
-   A failed test may be retaken by scheduling a new appointment and
    paying the fee again.
-   The system must enforce the required test sequence for first-time
    license issuance.

## 7. Issued Driving Licenses

After the applicant meets the eligibility requirements and passes all
required tests, the system shall issue a driving license with a validity
period based on the selected license class.

### 7.1 License information

Each issued license shall include:

-   License number
-   Photograph of the license holder
-   National number of the license holder
-   Name of the license holder
-   Date of birth of the license holder
-   License class
-   Issue date
-   Expiry date
-   License conditions or notes
-   Issuance status/type: `New`, `Replacement for Lost`,
    `Replacement for Damaged`, or `Renewal`

For a person's first license, the issuance status/type is `New`.

### 7.2 License inquiries

The system shall allow users to look up the licenses held by a person
using either:

-   The person's national number, or
-   The license number.

## 8. Driving-License Services

The system provides the following services. Service rules and fees below
are transcribed from the source requirements; any fee inconsistencies
are listed in the final clarification section.

### 8.1 First-Time Driving License

-   The applicant selects a license class.
-   The system checks the applicant's minimum age.
-   The system rejects the application if the applicant already holds a
    license of the same class.
-   The system checks that there is no unfinished application of the
    same type.
-   The applicant must provide valid identification and proof of
    completing the required training.
-   The applicant must pass the eyesight, theoretical, and practical
    tests in that order.
-   The issued license uses the validity period configured for the
    selected class.

### 8.2 Retest

-   Allows an applicant to schedule another attempt at a test by
    entering the previous test's number.
-   The applicant must have failed the previous test.
-   The service application fee is stated as **\$5**, in addition to the
    fee for the relevant test.
-   The appointment is scheduled manually by a system user.
-   A retest creates a new application linked to the original
    application.
-   The system must not allow two appointments for the same test.

### 8.3 Driving-License Renewal

-   Allows an applicant to renew a driving license.
-   The source states a renewal application fee of **\$10**.
-   The applicant must pass an eyesight test after paying its fee and
    scheduling an appointment.
-   The applicant must surrender the expired license before renewal.

### 8.4 Replacement for a Lost License

-   Allows an applicant to obtain a replacement for a lost license.
-   The system must verify that the license is not impounded before
    allowing the replacement.
-   The source states a service fee of **\$20**.
-   The source also says that the expired license must be surrendered
    before renewal; its applicability to a lost-license replacement is
    unclear and should be confirmed.

### 8.5 Replacement for a Damaged License

-   Allows an applicant to obtain a replacement for a damaged license.
-   The applicant must surrender the damaged license before a
    replacement is issued.
-   The source states a service fee of **\$20**.
-   The system must retain the date on which the damaged-license
    replacement was issued.

### 8.6 Release of an Impounded License

-   Allows an impounded driving license to be released.
-   The applicant must pay the fine associated with the impoundment.
-   The license must be returned to its owner.
-   The system must record the release date.

### 8.7 International Driving License

-   Allows an eligible person to obtain an international driving
    license.
-   The validity period is configurable in the system.
-   The service is available only to holders of a Class 3 ordinary
    driving license.
-   The qualifying Class 3 license must not be expired or impounded.
-   The source states a service fee of **\$20**.
-   The system must not leave more than one active international license
    for a person. If an active international license exists, it is
    cancelled and a new one is issued.
-   The system must retain records of all previously issued
    international licenses.

## 9. License Impoundment

The system shall allow an authorized user to impound a driving license
and record:

-   License number
-   Reason for impoundment
-   Fine associated with the impoundment
-   Impoundment date

The system must support the release process described in Section 8.6.

## 10. System Configuration

### 10.1 Test configuration

-   Test types are fixed and cannot be added or removed through the
    described administration feature.
-   Users may modify test fees.

### 10.2 License-class configuration

-   License classes are fixed and cannot be added or removed through the
    described administration feature.
-   Users may modify each class's minimum age, validity period, and
    license fee.

## 11. Audit Trail

For every operation performed in the system, the system must record:

-   The user who performed the operation
-   The date/time of the operation

## 12. Fees Summary

The following table summarizes amounts explicitly stated in the source.
Where the source provides different amounts for what may be interpreted
as the same fee, both statements are retained for review.

  -----------------------------------------------------------------------
  Item                                               Fee stated in source
  ------------------------------ ----------------------------------------
  General application fee in the                                      \$5
  introductory service list      

  First-time license --- Class 1   \$15 license fee, plus application fee

  First-time license --- Class 2   \$30 license fee, plus application fee

  First-time license --- Class 3   \$20 license fee, plus application fee

  First-time license --- Class 4  \$200 license fee, plus application fee

  First-time license --- Class 5   \$50 license fee, plus application fee

  First-time license --- Class 6  \$250 license fee, plus application fee

  First-time license --- Class 7  \$300 license fee, plus application fee

  Eyesight test                                                      \$10

  Theoretical test                                                   \$20

  Retest service application            \$5, plus the applicable test fee

  Renewal service application                                        \$10

  Lost-license replacement                                           \$20
  service                        

  Damaged-license replacement                                        \$20
  service                        

  International driving license                                      \$20
  service                        

  Release of impounded license           Fine amount is determined by the
                                                              impoundment
  -----------------------------------------------------------------------

## 13. Clarifications to Confirm

These points are intentionally not resolved here because the source
document does not provide a single unambiguous rule:

1.  **Application fees:** The introduction lists a \$5 application fee
    for each of the seven services, while detailed service sections
    specify \$10 for renewal and \$20 for lost/damaged replacement and
    international-license services. Confirm which fee values are
    authoritative.
2.  **Practical-test fee:** The source says test fees depend on the
    license class but does not provide a separate numeric fee for the
    practical test.
3.  **Lost-license replacement:** The source mentions surrendering an
    expired license in the lost-license section, although this may have
    been copied from the renewal requirement. Confirm the intended rule.
4.  **International license replacement:** The source says an existing
    active international license is cancelled before a new one is
    issued. Confirm whether this is intended to apply whenever a new
    international license is requested.
5.  **Application status and test outcomes:** The source defines
    application statuses as `New`, `Cancelled`, and `Completed`, and
    test results as pass/fail. It does not fully specify every
    transition between these states.

------------------------------------------------------------------------

## 14. Source Scope

This document reorganizes and translates the requirements present in the
supplied PDF. It does not introduce additional business rules beyond
what is stated there. Items in Section 13 are presented as clarification
questions rather than assumptions.
