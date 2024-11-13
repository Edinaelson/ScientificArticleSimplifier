using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ScientificArticleSimplifier.Services
{
    public class LlmServices
    {
        public static async Task<string> GenerateContentAsync(string question)
        {
            var apiKey = File.ReadAllText($"C:/dev/Estudo de MVC core/ScientificArticleSimplifier/apiGoogle.txt");
            using var httpClient = new HttpClient();

            var reader = File.ReadAllText("./Prompts/Prompt.txt")??"";
            var prompt = reader.Replace("{0}",question);

            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={apiKey}";

            // Corpo do conteúdo JSON da solicitação
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Envia a solicitação POST
                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    //parse do json para pegar apenas o campo text
                    using (JsonDocument jsonDocument = JsonDocument.Parse(responseContent))
                    {
                        // Acessa o texto em candidates[0].content.parts[0].text
                        string text = jsonDocument
                            .RootElement
                            .GetProperty("candidates")[0]
                            .GetProperty("content")
                            .GetProperty("parts")[0]
                            .GetProperty("text")
                            .GetString();
                        return text;
                    }
                }
                else
                {
                    return $"Erro: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                }
            }
            catch (Exception ex)
            {
                return $"Exceção: {ex.Message}";
            }
        }

    }
}
