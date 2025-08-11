namespace PerfScratchpad.Refs.ArrayPooledBlockingCollection;

internal static partial class SR
{
    /// <summary>CompleteAdding may not be used concurrently with additions to the collection.</summary>
    internal static string @BlockingCollection_Add_ConcurrentCompleteAdd => "BlockingCollection_Add_ConcurrentCompleteAdd";

    /// <summary>The underlying collection didn't accept the item.</summary>
    internal static string @BlockingCollection_Add_Failed => "BlockingCollection_Add_Failed";

    /// <summary>At least one of the specified collections is marked as complete with regards to additions.</summary>
    internal static string @BlockingCollection_CantAddAnyWhenCompleted =>
        "BlockingCollection_CantAddAnyWhenCompleted";
    /// <summary>All collections are marked as complete with regards to additions.</summary>
    internal static string @BlockingCollection_CantTakeAnyWhenAllDone => "BlockingCollection_CantTakeAnyWhenAllDone";
    /// <summary>The collection argument is empty and has been marked as complete with regards to additions.</summary>
    internal static string @BlockingCollection_CantTakeWhenDone => "BlockingCollection_CantTakeWhenDone";
    /// <summary>The collection has been marked as complete with regards to additions.</summary>
    internal static string @BlockingCollection_Completed => "BlockingCollection_Completed";
    /// <summary>The array argument is of the incorrect type.</summary>
    internal static string @BlockingCollection_CopyTo_IncorrectType => "BlockingCollection_CopyTo_IncorrectType";
    /// <summary>The array argument is multidimensional.</summary>
    internal static string @BlockingCollection_CopyTo_MultiDim => "BlockingCollection_CopyTo_MultiDim";
    /// <summary>The index argument must be greater than or equal zero.</summary>
    internal static string @BlockingCollection_CopyTo_NonNegative => "BlockingCollection_CopyTo_NonNegative";
    /// <summary>The number of elements in the collection is greater than the available space from index to the end of the destination array.</summary>
    internal static string @Collection_CopyTo_TooManyElems => "Collection_CopyTo_TooManyElems";
    /// <summary>The collection argument contains more items than are allowed by the boundedCapacity.</summary>
    internal static string @BlockingCollection_ctor_CountMoreThanCapacity => "BlockingCollection_ctor_CountMoreThanCapacity";
    /// <summary>The underlying collection was modified from outside of the BlockingCollection&lt;T&gt;.</summary>
    internal static string @BlockingCollection_Take_CollectionModified => "BlockingCollection_Take_CollectionModified";
    /// <summary>The specified timeout must represent a value between -1 and {0}, inclusive.</summary>
    internal static string @BlockingCollection_TimeoutInvalid => "BlockingCollection_TimeoutInvalid";
    /// <summary>The collections argument contains at least one disposed element.</summary>
    internal static string @BlockingCollection_ValidateCollectionsArray_DispElems => "BlockingCollection_ValidateCollectionsArray_DispElems";
    /// <summary>The collections length is greater than the supported range.</summary>
    internal static string @BlockingCollection_ValidateCollectionsArray_LargeSize => "BlockingCollection_ValidateCollectionsArray_LargeSize";
    /// <summary>The collections argument contains at least one null element.</summary>
    internal static string @BlockingCollection_ValidateCollectionsArray_NullElems => "BlockingCollection_ValidateCollectionsArray_NullElems";
    /// <summary>The collections argument is a zero-length array.</summary>
    internal static string @BlockingCollection_ValidateCollectionsArray_ZeroSize => "BlockingCollection_ValidateCollectionsArray_ZeroSize";
    /// <summary>The SyncRoot property may not be used for the synchronization of concurrent collections.</summary>
    internal static string @ConcurrentCollection_SyncRoot_NotSupported => "ConcurrentCollection_SyncRoot_NotSupported";
    /// <summary>The array is multidimensional, or the type parameter for the set cannot be cast automatically to the type of the destination array.</summary>
    internal static string @ConcurrentDictionary_ArrayIncorrectType => "ConcurrentDictionary_ArrayIncorrectType";
    /// <summary>The source argument contains duplicate keys.</summary>
    internal static string @ConcurrentDictionary_SourceContainsDuplicateKeys => "ConcurrentDictionary_SourceContainsDuplicateKeys";
    /// <summary>The concurrencyLevel argument must be positive, or -1 to indicate a default level.</summary>
    internal static string @ConcurrentDictionary_ConcurrencyLevelMustBePositiveOrNegativeOne => "ConcurrentDictionary_ConcurrencyLevelMustBePositiveOrNegativeOne";
    /// <summary>The index is equal to or greater than the length of the array, or the number of elements in the dictionary is greater than the available space from index to the end of the destination array.</summary>
    internal static string @ConcurrentDictionary_ArrayNotLargeEnough => "ConcurrentDictionary_ArrayNotLargeEnough";
    /// <summary>The key already existed in the dictionary.</summary>
    internal static string @ConcurrentDictionary_KeyAlreadyExisted => "ConcurrentDictionary_KeyAlreadyExisted";
    /// <summary>TKey is a reference type and item.Key is null.</summary>
    internal static string @ConcurrentDictionary_ItemKeyIsNull => "ConcurrentDictionary_ItemKeyIsNull";
    /// <summary>The key was of an incorrect type for this dictionary.</summary>
    internal static string @ConcurrentDictionary_TypeOfKeyIncorrect => "ConcurrentDictionary_TypeOfKeyIncorrect";
    /// <summary>The value was of an incorrect type for this dictionary.</summary>
    internal static string @ConcurrentDictionary_TypeOfValueIncorrect => "ConcurrentDictionary_TypeOfValueIncorrect";
    /// <summary>The sum of the startIndex and count arguments must be less than or equal to the collection's Count.</summary>
    internal static string @ConcurrentStack_PushPopRange_InvalidCount => "ConcurrentStack_PushPopRange_InvalidCount";
    /// <summary>Dynamic partitions are not supported by this partitioner.</summary>
    internal static string @Partitioner_DynamicPartitionsNotSupported => "Partitioner_DynamicPartitionsNotSupported";
    /// <summary>MoveNext must be called at least once before calling Current.</summary>
    internal static string @PartitionerStatic_CurrentCalledBeforeMoveNext => "PartitionerStatic_CurrentCalledBeforeMoveNext";
    /// <summary>Enumeration has either not started or has already finished.</summary>
    internal static string @ConcurrentBag_Enumerator_EnumerationNotStartedOrAlreadyFinished => "ConcurrentBag_Enumerator_EnumerationNotStartedOrAlreadyFinished";
    /// <summary>The given key '{0}' was not present in the dictionary.</summary>
    internal static string @Arg_KeyNotFoundWithKey => "Arg_KeyNotFoundWithKey";
    /// <summary>Hashtable's capacity overflowed and went negative. Check load factor, capacity and the current size of the table.</summary>
    internal static string @Arg_HTCapacityOverflow => "Arg_HTCapacityOverflow";
    /// <summary>The collection's comparer does not support the requested operation.</summary>
    internal static string @InvalidOperation_IncompatibleComparer => "InvalidOperation_IncompatibleComparer";

}