﻿using System;

using MsgPack.Light;

using Tarantool.Client.Model;
using Tarantool.Client.Model.Enums;
using Tarantool.Client.Model.Headers;
using Tarantool.Client.Model.Responses;

namespace Tarantool.Client.Utils
{
    public static class ExceptionHelper
    {
        public static Exception UnexpectedGreetingBytesCount(int readCount)
        {
            return new ArgumentException($"Invalid greetings response length. 128 is expected, but got {readCount}.");
        }
        
        public static Exception InvalidMapLength(uint expected, uint? actual)
        {
            return new ArgumentException($"Invalid map length: {expected} is expected, but got {actual}.");
        }

        public static Exception UnexpectedKey(Key actual, params Key[] expected)
        {
            return new ArgumentException($"Unexpected key: {String.Join(", ", expected)} is expected, but got {actual}.");
        }

        public static Exception InvalidArrayLength(uint expected, uint? actual)
        {
            return new ArgumentException($"Invalid array length: {expected} is expected, but got {actual}.");
        }

        public static Exception UnexpectedDataType(DataTypes expected, DataTypes actual)
        {
            return new ArgumentException($"Unexpected data type: {expected} is expected, but got {actual}.");
        }

        public static Exception NotConnected()
        {
            return new InvalidOperationException("Can't perform operation. Looks like we are not connected to tarantool. Call 'Connect' method before calling any other operations.");
        }

        public static ArgumentException TarantoolError(ResponseHeader header, ErrorResponse errorResponse)
        {
            return new ArgumentException($"Tarantool returns an error with code: 0x{header.Code:X}  and message: {errorResponse.ErrorMessage}");
        }

        public static ArgumentOutOfRangeException WrongRequestId(RequestId requestId)
        {
            return new ArgumentOutOfRangeException($"Can't find pending request with id = {requestId}");
        }

        public static ArgumentException InvalidSpaceName(string name)
        {
            return new ArgumentException($"Space with name '{name}' was found!");
        }

        public static ArgumentException InvalidSpaceId(uint id)
        {
            return new ArgumentException($"Space with id '{id}' was not found!");
        }

        public static ArgumentException InvalidIndexName(string indexName, string space)
        {
            return new ArgumentException($"Index with name '{indexName}' was not found in space {space}!");
        }

        public static ArgumentException InvalidIndexId(uint indexId, string space)
        {
            return new ArgumentException($"Index with id '{indexId}' was found in space {space}!");
        }

        public static Exception PropertyUnspecified(string propertyName)
        {
            return new ArgumentException($"Property '{propertyName}' is not specified!");
        }

        public static InvalidOperationException EmptyUsernameInGuestMode()
        {
            return new InvalidOperationException("Empty username in non-guest mode! Please specify username or enable guest mode.");
        }

        public static InvalidOperationException EnumExpected(Type type)
        {
            return new InvalidOperationException($"Enum expected, but got {type}.");
        }

        public static InvalidOperationException UnexpectedEnumUnderlyingType(Type enumUnderlyingType)
        {
            return new InvalidOperationException($"Unexpected underlying enum type: {enumUnderlyingType}.");
        }

        public static ArgumentException UnknownIndexCreationOption(string key)
        {
            return new ArgumentException($"Unknown index creation option: {key}");
        }

        public static ArgumentException UnexpectedSpaceFieldKey(string key)
        {
            return new ArgumentException($"Invalid SpaceField key: {key}");
        }

        public static NotSupportedException WrongIndexType(string indexType, string operation)
        {
            return new NotSupportedException($"Only {indexType} indicies support {operation} operation.");
        }
    }
}