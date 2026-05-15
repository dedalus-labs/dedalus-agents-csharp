using System.Text.Json;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Images;
using DedalusSdk.Models.Models;
using Completions = DedalusSdk.Models.Chat.Completions;
using Embeddings = DedalusSdk.Models.Embeddings;
using Responses = DedalusSdk.Models.Responses;
using Speech = DedalusSdk.Models.Audio.Speech;

namespace DedalusSdk.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Truncation>(),
            new ApiEnumConverter<string, Effort>(),
            new ApiEnumConverter<string, GenerateSummary>(),
            new ApiEnumConverter<string, Summary>(),
            new ApiEnumConverter<string, UnionMember0>(),
            new ApiEnumConverter<string, Object>(),
            new ApiEnumConverter<string, Provider>(),
            new ApiEnumConverter<string, Embeddings::CreateEmbeddingRequestModel>(),
            new ApiEnumConverter<string, Embeddings::CreateEmbeddingRequestEncodingFormat>(),
            new ApiEnumConverter<string, Embeddings::Model>(),
            new ApiEnumConverter<string, Embeddings::EncodingFormat>(),
            new ApiEnumConverter<string, Speech::Model>(),
            new ApiEnumConverter<string, Speech::UnionMember1>(),
            new ApiEnumConverter<string, Speech::ResponseFormat>(),
            new ApiEnumConverter<string, Speech::StreamFormat>(),
            new ApiEnumConverter<string, CreateImageRequestBackground>(),
            new ApiEnumConverter<string, CreateImageRequestModeration>(),
            new ApiEnumConverter<string, CreateImageRequestOutputFormat>(),
            new ApiEnumConverter<string, CreateImageRequestQuality>(),
            new ApiEnumConverter<string, CreateImageRequestResponseFormat>(),
            new ApiEnumConverter<string, CreateImageRequestSize>(),
            new ApiEnumConverter<string, CreateImageRequestStyle>(),
            new ApiEnumConverter<string, Background>(),
            new ApiEnumConverter<string, Moderation>(),
            new ApiEnumConverter<string, OutputFormat>(),
            new ApiEnumConverter<string, Quality>(),
            new ApiEnumConverter<string, ResponseFormat>(),
            new ApiEnumConverter<string, Size>(),
            new ApiEnumConverter<string, Style>(),
            new ApiEnumConverter<string, Responses::Status>(),
            new ApiEnumConverter<string, Responses::Object>(),
            new ApiEnumConverter<string, Responses::ResponseResponseCreateParamsServiceTier>(),
            new ApiEnumConverter<string, Responses::ResponseResponseCreateParamsTruncation>(),
            new ApiEnumConverter<string, Responses::ServiceTier>(),
            new ApiEnumConverter<string, Responses::Truncation>(),
            new ApiEnumConverter<string, Completions::ServiceTier>(),
            new ApiEnumConverter<string, Completions::Format>(),
            new ApiEnumConverter<string, Completions::UnionMember1>(),
            new ApiEnumConverter<string, Completions::ChatCompletionChunkServiceTier>(),
            new ApiEnumConverter<string, Completions::Detail>(),
            new ApiEnumConverter<string, Completions::InputAudioFormat>(),
            new ApiEnumConverter<string, Completions::ChatCompletionCreateParamsPromptMode>(),
            new ApiEnumConverter<
                string,
                Completions::ChatCompletionCreateParamsSafetySettingCategory
            >(),
            new ApiEnumConverter<
                string,
                Completions::ChatCompletionCreateParamsSafetySettingThreshold
            >(),
            new ApiEnumConverter<string, Completions::ChatCompletionCreateParamsSpeed>(),
            new ApiEnumConverter<string, Completions::Type>(),
            new ApiEnumConverter<string, Completions::FinishReason>(),
            new ApiEnumConverter<string, Completions::Role>(),
            new ApiEnumConverter<string, Completions::ChoiceDeltaToolCallType>(),
            new ApiEnumConverter<string, Completions::StreamChoiceFinishReason>(),
            new ApiEnumConverter<string, Completions::PromptMode>(),
            new ApiEnumConverter<string, Completions::Category>(),
            new ApiEnumConverter<string, Completions::Threshold>(),
            new ApiEnumConverter<string, Completions::Speed>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
