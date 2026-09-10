using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AssignmentProject;

public class ApiService
{
    private readonly HttpClient _httpClient;
    
    public ApiService(string baseUrl)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }
    
    public async Task<List<T>> GetAllAsync<T>(string endpoint)
    {
        return await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
    }
    
    public async Task<T> GetAsync<T>(string endpoint, int id)
    {
        return await _httpClient.GetFromJsonAsync<T>($"{endpoint}/{id}");
    }
    
    public async Task<string> CreateAsync<T>(string endpoint, T item)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, item);
        return ((int)response.StatusCode).ToString();
    }
    
    public async Task<string> UpdateAsync<T>(string endpoint, int id, T item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{endpoint}/{id}", item);
        return ((int)response.StatusCode).ToString();
    }
    
    public async Task<string> DeleteAsync(string endpoint, int id)
    {
        var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
        return ((int)response.StatusCode).ToString();
    }
}
