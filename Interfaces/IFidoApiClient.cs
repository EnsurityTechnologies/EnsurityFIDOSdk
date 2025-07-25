using FidoClientSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FidoClientSdk.Interfaces
{
    public interface IFidoApiClient
    {
        Task<BaseResponse> ServerCredentialsRequestAsync(ServerCredentialsDto request);
        Task<MakeCredentialResponse> MakeCredentialRequestAsync(MakeCredentialRequest request);
        Task<BaseResponse> MakeCredentialResponseAsync(MakeCredentialFinishRequest responseData);
        Task<GetAssertionResponse> GetAssertionRequestAsync(GetAssertionRequest requestData);
        Task<BaseResponse> GetAssertionResponseAsync(GetAssertionFinishRequest responseData);
    }
}
