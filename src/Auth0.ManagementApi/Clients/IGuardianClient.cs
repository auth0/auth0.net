namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IGuardianClient
  {
    /// <summary>
    /// Generate an email with a link to start the Guardian enrollment process.
    /// </summary>
    /// <param name="request">
    /// The <see cref="CreateGuardianEnrollmentTicketRequest" /> containing the information about the user who should be enrolled.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that was created.</returns>
    Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an enrollment.
    /// </summary>
    /// <param name="id">The ID of the enrollment to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteEnrollmentAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an enrollment.
    /// </summary>
    /// <param name="id">The ID of the enrollment to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianEnrollment"/> containing details of the enrollment.</returns>
    Task<GuardianEnrollment> GetEnrollmentAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all factors. Useful to check factor enablement and trial status.
    /// </summary>
    /// <returns>List of <see cref="GuardianFactor" /> instances with the available factors.</returns>
    Task<IList<GuardianFactor>> GetFactorsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
    /// </summary>
    /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
    Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns provider configuration for AWS SNS.
    /// </summary>
    /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
    Task<GuardianSnsConfiguration> GetSnsConfigurationAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns configuration for the Guardian Twilio provider.
    /// </summary>
    /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
    Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Enable or Disable a Guardian factor.
    /// </summary>
    /// <param name="request">The <see cref="UpdateGuardianFactorRequest" /> containing the details of the factor to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="UpdateGuardianFactorResponse" /> indicating the status of the factor.</returns>
    Task<UpdateGuardianFactorResponse> UpdateFactorAsync(UpdateGuardianFactorRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
    /// </summary>
    /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
    Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates, CancellationToken cancellationToken = default);

    /// <summary>
    /// Configure the Guardian Twilio provider.
    /// </summary>
    /// <param name="request">
    /// The <see cref="UpdateGuardianTwilioConfigurationRequest" /> containing the configuration settings.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="GuardianTwilioConfiguration" /> containing the updated configuration settings.</returns>
    Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(UpdateGuardianTwilioConfigurationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the enabled phone factors for multi-factor authentication
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
    Task<GuardianPhoneMessageTypes> GetPhoneMessageTypesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update enabled phone factors for multi-factor authentication
    /// </summary>
    /// <param name="messageTypes">A <see cref="GuardianPhoneMessageTypes" /> containing the list of phone factors to enable on the tenan.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
    Task<GuardianPhoneMessageTypes> UpdatePhoneMessageTypesAsync(GuardianPhoneMessageTypes messageTypes, CancellationToken cancellationToken = default);
  }
}
