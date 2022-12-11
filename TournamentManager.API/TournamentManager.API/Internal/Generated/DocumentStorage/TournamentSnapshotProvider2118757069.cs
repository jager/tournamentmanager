// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System;
using System.Collections.Generic;
using TournamentManager.Domain.Tournaments;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertTournamentSnapshotOperation2118757069
    public class UpsertTournamentSnapshotOperation2118757069 : Marten.Internal.Operations.StorageOperation<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly TournamentManager.Domain.Tournaments.TournamentSnapshot _document;
        private readonly int _id;
        private readonly System.Collections.Generic.Dictionary<int, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertTournamentSnapshotOperation2118757069(TournamentManager.Domain.Tournaments.TournamentSnapshot document, int id, System.Collections.Generic.Dictionary<int, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_tournamentsnapshot(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Integer;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }

    }

    // END: UpsertTournamentSnapshotOperation2118757069
    
    
    // START: InsertTournamentSnapshotOperation2118757069
    public class InsertTournamentSnapshotOperation2118757069 : Marten.Internal.Operations.StorageOperation<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly TournamentManager.Domain.Tournaments.TournamentSnapshot _document;
        private readonly int _id;
        private readonly System.Collections.Generic.Dictionary<int, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertTournamentSnapshotOperation2118757069(TournamentManager.Domain.Tournaments.TournamentSnapshot document, int id, System.Collections.Generic.Dictionary<int, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_tournamentsnapshot(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Integer;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }

    }

    // END: InsertTournamentSnapshotOperation2118757069
    
    
    // START: UpdateTournamentSnapshotOperation2118757069
    public class UpdateTournamentSnapshotOperation2118757069 : Marten.Internal.Operations.StorageOperation<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly TournamentManager.Domain.Tournaments.TournamentSnapshot _document;
        private readonly int _id;
        private readonly System.Collections.Generic.Dictionary<int, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateTournamentSnapshotOperation2118757069(TournamentManager.Domain.Tournaments.TournamentSnapshot document, int id, System.Collections.Generic.Dictionary<int, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_tournamentsnapshot(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Integer;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }

    }

    // END: UpdateTournamentSnapshotOperation2118757069
    
    
    // START: QueryOnlyTournamentSnapshotSelector2118757069
    public class QueryOnlyTournamentSnapshotSelector2118757069 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<TournamentManager.Domain.Tournaments.TournamentSnapshot>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyTournamentSnapshotSelector2118757069(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public TournamentManager.Domain.Tournaments.TournamentSnapshot Resolve(System.Data.Common.DbDataReader reader)
        {

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = _serializer.FromJson<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<TournamentManager.Domain.Tournaments.TournamentSnapshot> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = await _serializer.FromJsonAsync<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyTournamentSnapshotSelector2118757069
    
    
    // START: LightweightTournamentSnapshotSelector2118757069
    public class LightweightTournamentSnapshotSelector2118757069 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>, Marten.Linq.Selectors.ISelector<TournamentManager.Domain.Tournaments.TournamentSnapshot>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightTournamentSnapshotSelector2118757069(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public TournamentManager.Domain.Tournaments.TournamentSnapshot Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<int>(0);

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = _serializer.FromJson<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<TournamentManager.Domain.Tournaments.TournamentSnapshot> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<int>(0, token);

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = await _serializer.FromJsonAsync<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightTournamentSnapshotSelector2118757069
    
    
    // START: IdentityMapTournamentSnapshotSelector2118757069
    public class IdentityMapTournamentSnapshotSelector2118757069 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>, Marten.Linq.Selectors.ISelector<TournamentManager.Domain.Tournaments.TournamentSnapshot>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapTournamentSnapshotSelector2118757069(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public TournamentManager.Domain.Tournaments.TournamentSnapshot Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<int>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = _serializer.FromJson<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<TournamentManager.Domain.Tournaments.TournamentSnapshot> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<int>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = await _serializer.FromJsonAsync<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapTournamentSnapshotSelector2118757069
    
    
    // START: DirtyTrackingTournamentSnapshotSelector2118757069
    public class DirtyTrackingTournamentSnapshotSelector2118757069 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>, Marten.Linq.Selectors.ISelector<TournamentManager.Domain.Tournaments.TournamentSnapshot>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingTournamentSnapshotSelector2118757069(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public TournamentManager.Domain.Tournaments.TournamentSnapshot Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<int>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = _serializer.FromJson<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<TournamentManager.Domain.Tournaments.TournamentSnapshot> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<int>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            TournamentManager.Domain.Tournaments.TournamentSnapshot document;
            document = await _serializer.FromJsonAsync<TournamentManager.Domain.Tournaments.TournamentSnapshot>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingTournamentSnapshotSelector2118757069
    
    
    // START: QueryOnlyTournamentSnapshotDocumentStorage2118757069
    public class QueryOnlyTournamentSnapshotDocumentStorage2118757069 : Marten.Internal.Storage.QueryOnlyDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyTournamentSnapshotDocumentStorage2118757069(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override int AssignIdentity(TournamentManager.Domain.Tournaments.TournamentSnapshot document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override int Identity(TournamentManager.Domain.Tournaments.TournamentSnapshot document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyTournamentSnapshotSelector2118757069(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(int id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int32[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: QueryOnlyTournamentSnapshotDocumentStorage2118757069
    
    
    // START: LightweightTournamentSnapshotDocumentStorage2118757069
    public class LightweightTournamentSnapshotDocumentStorage2118757069 : Marten.Internal.Storage.LightweightDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightTournamentSnapshotDocumentStorage2118757069(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override int AssignIdentity(TournamentManager.Domain.Tournaments.TournamentSnapshot document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override int Identity(TournamentManager.Domain.Tournaments.TournamentSnapshot document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightTournamentSnapshotSelector2118757069(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(int id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int32[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: LightweightTournamentSnapshotDocumentStorage2118757069
    
    
    // START: IdentityMapTournamentSnapshotDocumentStorage2118757069
    public class IdentityMapTournamentSnapshotDocumentStorage2118757069 : Marten.Internal.Storage.IdentityMapDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapTournamentSnapshotDocumentStorage2118757069(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override int AssignIdentity(TournamentManager.Domain.Tournaments.TournamentSnapshot document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override int Identity(TournamentManager.Domain.Tournaments.TournamentSnapshot document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapTournamentSnapshotSelector2118757069(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(int id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int32[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: IdentityMapTournamentSnapshotDocumentStorage2118757069
    
    
    // START: DirtyTrackingTournamentSnapshotDocumentStorage2118757069
    public class DirtyTrackingTournamentSnapshotDocumentStorage2118757069 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingTournamentSnapshotDocumentStorage2118757069(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override int AssignIdentity(TournamentManager.Domain.Tournaments.TournamentSnapshot document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTournamentSnapshotOperation2118757069
            (
                document, Identity(document),
                session.Versions.ForType<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override int Identity(TournamentManager.Domain.Tournaments.TournamentSnapshot document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingTournamentSnapshotSelector2118757069(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(int id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int32[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: DirtyTrackingTournamentSnapshotDocumentStorage2118757069
    
    
    // START: TournamentSnapshotBulkLoader2118757069
    public class TournamentSnapshotBulkLoader2118757069 : Marten.Internal.CodeGeneration.BulkLoader<TournamentManager.Domain.Tournaments.TournamentSnapshot, int>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int> _storage;

        public TournamentSnapshotBulkLoader2118757069(Marten.Internal.Storage.IDocumentStorage<TournamentManager.Domain.Tournaments.TournamentSnapshot, int> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_tournamentsnapshot(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_tournamentsnapshot_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_tournamentsnapshot (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_tournamentsnapshot_temp.\"id\", mt_doc_tournamentsnapshot_temp.\"data\", mt_doc_tournamentsnapshot_temp.\"mt_version\", mt_doc_tournamentsnapshot_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_tournamentsnapshot_temp left join public.mt_doc_tournamentsnapshot on mt_doc_tournamentsnapshot_temp.id = public.mt_doc_tournamentsnapshot.id where public.mt_doc_tournamentsnapshot.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_tournamentsnapshot target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_tournamentsnapshot_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_tournamentsnapshot_temp as select * from public.mt_doc_tournamentsnapshot limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Integer);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, TournamentManager.Domain.Tournaments.TournamentSnapshot document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Integer, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }

    }

    // END: TournamentSnapshotBulkLoader2118757069
    
    
    // START: TournamentSnapshotProvider2118757069
    public class TournamentSnapshotProvider2118757069 : Marten.Internal.Storage.DocumentProvider<TournamentManager.Domain.Tournaments.TournamentSnapshot>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public TournamentSnapshotProvider2118757069(Marten.Schema.DocumentMapping mapping) : base(new TournamentSnapshotBulkLoader2118757069(new QueryOnlyTournamentSnapshotDocumentStorage2118757069(mapping)), new QueryOnlyTournamentSnapshotDocumentStorage2118757069(mapping), new LightweightTournamentSnapshotDocumentStorage2118757069(mapping), new IdentityMapTournamentSnapshotDocumentStorage2118757069(mapping), new DirtyTrackingTournamentSnapshotDocumentStorage2118757069(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: TournamentSnapshotProvider2118757069
    
    
}

