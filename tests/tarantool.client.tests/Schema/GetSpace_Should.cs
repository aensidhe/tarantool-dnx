﻿using System;
using System.Threading.Tasks;

using Xunit;

using Shouldly;

using ProGaudi.Tarantool.Client.Model;

namespace ProGaudi.Tarantool.Client.Tests.Schema
{
    public class GetSpace_Should
    {
        [Fact]
        public async Task throw_expection_for_non_existing_space_by_name()
        {
            var tarantoolClient = await Client.Box.Connect("127.0.0.1:3301");

            var schema = tarantoolClient.GetSchema();

            await schema.GetSpace("non-existing").ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task throw_expection_for_non_existing_space_by_id()
        {
            var tarantoolClient = await Client.Box.Connect("127.0.0.1:3301");

            var schema = tarantoolClient.GetSchema();

            await schema.GetSpace(12341234).ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task returns_space_by_id()
        {
            const uint VSpaceId = 0x119; // that space always exist and contains other spaces.
            var tarantoolClient = await Client.Box.Connect("127.0.0.1:3301");

            var schema = tarantoolClient.GetSchema();

            var space = await schema.GetSpace(VSpaceId);

            space.Id.ShouldBe(VSpaceId);
        }

        [Fact]
        public async Task returns_space_by_name()
        {
            const string VSpaceName = "_vspace"; // that space always exist and contains other spaces.
            var tarantoolClient = await Client.Box.Connect("127.0.0.1:3301");

            var schema = tarantoolClient.GetSchema();

            var space = await schema.GetSpace(VSpaceName);

            space.Name.ShouldBe(VSpaceName);
        }

        [Fact]
        public async Task read_multiple_spaces_in_a_row()
        {
            const string VSpaceName = "_vspace"; // that space always exist and contains other spaces.
            var tarantoolClient = await Client.Box.Connect("127.0.0.1:3301");

            var schema = tarantoolClient.GetSchema();

            for (int i = 0; i < 10; i++)
            {
                var space = await schema.GetSpace(VSpaceName);

                space.Name.ShouldBe(VSpaceName);
            }
        }
    }
}