﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TogglRestApi.Models;
using TogglRestApi.Models.ProjectModels;

namespace TogglRestApi
{
    public class RestApi
    {
        private UserDataToggl userRequestInfo;
        private string token;
        public RestApi()
        {
        }

        private async Task<T> BasicAuthorizationRequest<T, U>(string webUrl, U postData = null, string method = "POST") where T : class
                                                                    where U : class
        {
            var request = (HttpWebRequest)WebRequest.Create(webUrl);
            request.Headers.Add("Authorization", "Basic " + token);
            request.Method = method;

            if (postData != null)
            {
                request.ContentType = @"application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(postData);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

            }

            try
            {
                var httpResponse = (HttpWebResponse) request.GetResponseAsync().Result;
                using (var sr = httpResponse.GetResponseStream())
                {
                    var responseJson = new StreamReader(sr).ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("There was a problem: " + e.Message);
                throw e;
            }
            return default(T);
        }

        public async Task<DataToggl<UserDataToggl>> Login(User user)
        {
            token = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(user.Username + ":" + user.Password));

            var response = await BasicAuthorizationRequest<DataToggl<UserDataToggl>, User>("https://www.toggl.com/api/v8/me", method:"GET");
            userRequestInfo = response.data;
            token = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(userRequestInfo.api_token + ":api_token"));
            return response;
        }

        public async Task<TimeEntries> CreateTimeEntries(TimeEntries timeEntries)
        {
            return await BasicAuthorizationRequest<TimeEntries, TimeEntries>("https://www.toggl.com/api/v9/time_entries", timeEntries);
        }

        public async Task<TimeEntries> CurrentTimeEntries()
        {
            return await BasicAuthorizationRequest<TimeEntries, TimeEntries>("https://www.toggl.com/api/v8/time_entries/current", method: "GET");
        }

        public async Task<TimeEntries> StartTimeEntry(StartTimeEntry timeEntries)
        {
            return await BasicAuthorizationRequest<TimeEntries, TimeEntryPostData>("https://www.toggl.com/api/v8/time_entries/start", new TimeEntryPostData(timeEntries));
        }

        public async Task<DataToggl<TimeEntries>> StopTimeEntry(int id)
        {
            return await BasicAuthorizationRequest<DataToggl<TimeEntries>, TimeEntries>($"https://www.toggl.com/api/v8/time_entries/{id}/stop", method: "PUT");
        }

        public async Task<DataToggl<TimeEntries>> GetTimeEntry(int id)
        {
            return await BasicAuthorizationRequest<DataToggl<TimeEntries>, TimeEntries>($"https://www.toggl.com/api/v8/time_entries/{id}", method: "GET");
        }

        public async Task<TimeEntries> UpdateTimeEntries(TimeEntries timeEntries)
        {
            return await BasicAuthorizationRequest<TimeEntries, TimeEntries>($"https://www.toggl.com/api/v8/time_entries/{timeEntries.id}", timeEntries, "PUT");
        }

        public async Task<TimeEntries> DeleteTimeEntries(int id)
        {
            return await BasicAuthorizationRequest<TimeEntries, TimeEntries>($"https://www.toggl.com/api/v8/time_entries/{id}", method: "DELETE"); 
        }

        public async Task<DataToggl<UserDataToggl>> UpdateUserData(EditableUserData editableUserData)
        {
            var response = await BasicAuthorizationRequest<DataToggl<UserDataToggl>, EditableUserData>("https://www.toggl.com/api/v8/me", editableUserData, "PUT");
            userRequestInfo = response.data;
            return response;
        }

        public async Task<DataToggl<UserDataToggl>> SignUp(SignUpData signUpData)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.toggl.com/api/v8/signups");
            request.Method = "POST";


            request.ContentType = @"application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(signUpData); 

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponseAsync().Result;
                using (var sr = httpResponse.GetResponseStream())
                {
                    var responseJson = new StreamReader(sr).ReadToEnd();
                    return JsonConvert.DeserializeObject<DataToggl<UserDataToggl>>(responseJson);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("There was a problem: " + e.Message);
                throw e;
            }
        }

        public async Task<DataToggl<ProjectToggl>> CreateProject(ProjectToggl projectToggl)
        {
            return await BasicAuthorizationRequest<DataToggl<ProjectToggl>, ProjectToggl>("https://www.toggl.com/api/v8/projects", projectToggl);
        }

        public async Task<DataToggl<ProjectToggl>> UpdateProject(ProjectToggl projectToggl)
        {
            return await BasicAuthorizationRequest<DataToggl<ProjectToggl>, ProjectPostData>($"https://www.toggl.com/api/v8/projects/{projectToggl.id}", new ProjectPostData(projectToggl), "PUT");
        }

        public async Task<List<WorkspaceToggl>> GetWorkspaces()
        {
            return await BasicAuthorizationRequest<List<WorkspaceToggl>, WorkspaceToggl>($"https://www.toggl.com/api/v8/workspaces", method: "GET");
        }

        public async Task<List<ProjectToggl>> GetWorkspaceProjects(int workspaceId)
        {
            return await BasicAuthorizationRequest<List<ProjectToggl>, ProjectToggl>($"https://www.toggl.com/api/v8/workspaces/{workspaceId}/projects", method: "GET");
        }
    }
}
