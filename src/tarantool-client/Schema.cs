﻿using System;

namespace tarantool_client
{
    public class Schema
    {
        public Space CreateSpace(string spaceName, SpaceCreationOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Space GetSpace(string name)
        {
            throw new NotImplementedException();
        }

        public Space GetSpace(uint id)
        {
            throw new NotImplementedException();
        }
    }
}