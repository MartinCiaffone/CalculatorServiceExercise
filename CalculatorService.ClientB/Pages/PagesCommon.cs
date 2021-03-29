using CalculatorService.ClientB.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CalculatorService.ClientB.Pages
{
    public static class PagesCommon
    {
        internal static async Task<Object> ExecuteOperation(Object input, HttpClient client)
        {
            try
            {
                //Id on Header
                client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", Startup.UserDefinedId);

                // Uses System.Net.Http.Json (NuGet) extension methods.
                HttpResponseMessage response;
                if (input is AdditionModel modelA)
                {
                    response = await client.PostAsJsonAsync<AdditionModel>("calculator/add/", modelA);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<AdditionResultModel>();
                }
                else if (input is SubtractModel modelS)
                {
                    response = await client.PostAsJsonAsync<SubtractModel>("calculator/sub/", modelS);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<SubtractResultModel>();
                }
                else if (input is MultiplyModel modelM)
                {
                    response = await client.PostAsJsonAsync<MultiplyModel>("calculator/mult/", modelM);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<MultiplyResultModel>();
                }
                else if (input is DivideModel modelD)
                {
                    response = await client.PostAsJsonAsync<DivideModel>("calculator/div/", modelD);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<DivideResultModel>();
                }
                else if (input is SquareRootModel modelR)
                {
                    response = await client.PostAsJsonAsync<SquareRootModel>("calculator/sqrt/", modelR);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<SquareRootResultModel>();
                }
                else if (input is JournalModel modelJ)
                {
                    response = await client.PostAsJsonAsync<JournalModel>("calculator/journal/", modelJ);
                    if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<JournalResultModel>();
                }
                else
                {
                    ErrorResponseModel errorResponse = new()
                    {
                        ErrorMessage = "Operation Not Implemented"
                    };
                    return errorResponse;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ErrorResponseModel errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseModel>();
                    return errorResponse;
                }
                else
                {
                    ErrorResponseModel errorResponse = new();
                    errorResponse.ErrorMessage = $"There was an error getting the response, reason: {response.ReasonPhrase}";
                    return errorResponse;
                }
            }
            catch (Exception ex)
            {
                ErrorResponseModel errorResponse = new()
                {
                    ErrorMessage = $"There was an error, reason: {ex.Message}"
                };
                return errorResponse;
            }
        }
    }
}
