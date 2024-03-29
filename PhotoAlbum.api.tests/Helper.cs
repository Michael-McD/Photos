﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoAlbum.api.tests
{
    public class DelegatingHandlerStub : DelegatingHandler
    {
        private readonly HttpResponseMessage responseMessage;

        public DelegatingHandlerStub(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(responseMessage);
        }
    }
}
