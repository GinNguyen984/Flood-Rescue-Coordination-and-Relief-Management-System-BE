using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class RescueManagementDbContext : DbContext
{
    public RescueManagementDbContext()
    {
    }

    public RescueManagementDbContext(DbContextOptions<RescueManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<GeographicArea> GeographicAreas { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<ReliefDistribution> ReliefDistributions { get; set; }

    public virtual DbSet<ReliefItem> ReliefItems { get; set; }

    public virtual DbSet<ReliefWarehouse> ReliefWarehouses { get; set; }

    public virtual DbSet<RequestLog> RequestLogs { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<RequestVerification> RequestVerifications { get; set; }

    public virtual DbSet<RescueAssignment> RescueAssignments { get; set; }

    public virtual DbSet<RescueRequest> RescueRequests { get; set; }

    public virtual DbSet<RescueShift> RescueShifts { get; set; }

    public virtual DbSet<RescueTeam> RescueTeams { get; set; }

    public virtual DbSet<RescueTeamMember> RescueTeamMembers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UrgencyLevel> UrgencyLevels { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<WarehouseInventory> WarehouseInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=database.purintech.id.vn;user=etoet;password=etoet;Database=RescueManagementDB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AppUser__B9BE370FD9EFBCCC");

            entity.ToTable("AppUser");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Area).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__AppUser__area_id__412EB0B6");

            entity.HasOne(d => d.Role).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__AppUser__role_id__403A8C7D");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__B74DF4E23EC24C46");

            entity.ToTable("Attachment");

            entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("file_type");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("file_url");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.UploadedAt)
                .HasColumnType("datetime")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK__Attachmen__rescu__76969D2E");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK__Attachmen__uploa__778AC167");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__5AF33E33930717D8");

            entity.ToTable("AuditLog");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.ActionAt)
                .HasColumnType("datetime")
                .HasColumnName("action_at");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.ActorRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actor_role");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("entity_name");

            entity.HasOne(d => d.Actor).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("FK__AuditLog__actor___7E37BEF6");
        });

        modelBuilder.Entity<GeographicArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Geograph__985D6D6B0D68A298");

            entity.ToTable("GeographicArea");

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area_name");
            entity.Property(e => e.ParentAreaId).HasColumnName("parent_area_id");

            entity.HasOne(d => d.ParentArea).WithMany(p => p.InverseParentArea)
                .HasForeignKey(d => d.ParentAreaId)
                .HasConstraintName("FK__Geographi__paren__398D8EEE");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionId).HasName("PK__Inventor__C807F3E60C933950");

            entity.ToTable("InventoryTransaction");

            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventory_transaction_id");
            entity.Property(e => e.ConfirmedAt)
                .HasColumnType("datetime")
                .HasColumnName("confirmed_at");
            entity.Property(e => e.ConfirmedBy).HasColumnName("confirmed_by");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transaction_type");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.InventoryTransactionConfirmedByNavigations)
                .HasForeignKey(d => d.ConfirmedBy)
                .HasConstraintName("FK__Inventory__confi__6FE99F9F");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransactionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Inventory__creat__6EF57B66");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK__Inventory__rescu__6E01572D");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__Inventory__wareh__6D0D32F4");
        });

        modelBuilder.Entity<ReliefDistribution>(entity =>
        {
            entity.HasKey(e => e.DistributionId).HasName("PK__ReliefDi__330512D4BFE12A10");

            entity.ToTable("ReliefDistribution");

            entity.Property(e => e.DistributionId).HasColumnName("distribution_id");
            entity.Property(e => e.DistributedAt)
                .HasColumnType("datetime")
                .HasColumnName("distributed_at");
            entity.Property(e => e.DistributionStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("distribution_status");
            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventory_transaction_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.InventoryTransactionId)
                .HasConstraintName("FK__ReliefDis__inven__72C60C4A");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.ReliefItemId)
                .HasConstraintName("FK__ReliefDis__relie__73BA3083");
        });

        modelBuilder.Entity<ReliefItem>(entity =>
        {
            entity.HasKey(e => e.ReliefItemId).HasName("PK__ReliefIt__784AD54C36F3BFA8");

            entity.ToTable("ReliefItem");

            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<ReliefWarehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__ReliefWa__734FE6BFA0F1F865");

            entity.ToTable("ReliefWarehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.LocationDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location_description");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warehouse_name");

            entity.HasOne(d => d.Area).WithMany(p => p.ReliefWarehouses)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__ReliefWar__area___6477ECF3");
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__RequestL__9E2397E09416E70F");

            entity.ToTable("RequestLog");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PerformedBy).HasColumnName("performed_by");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");

            entity.HasOne(d => d.PerformedByNavigation).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.PerformedBy)
                .HasConstraintName("FK__RequestLo__perfo__7B5B524B");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK__RequestLo__rescu__7A672E12");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__RequestS__3683B531D97D77D2");

            entity.ToTable("RequestStatus");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsFinal).HasColumnName("is_final");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<RequestVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__RequestV__24F179698D0E1578");

            entity.ToTable("RequestVerification");

            entity.Property(e => e.VerificationId).HasColumnName("verification_id");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.VerificationStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("verification_status");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("verified_at");
            entity.Property(e => e.VerifiedBy).HasColumnName("verified_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK__RequestVe__rescu__49C3F6B7");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.VerifiedBy)
                .HasConstraintName("FK__RequestVe__verif__4AB81AF0");
        });

        modelBuilder.Entity<RescueAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__RescueAs__DA891814110CC9E4");

            entity.ToTable("RescueAssignment");

            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.AssignedAt)
                .HasColumnType("datetime")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.AssignmentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assignment_status");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.RejectReason)
                .HasColumnType("text")
                .HasColumnName("reject_reason");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.ShiftId).HasColumnName("shift_id");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("FK__RescueAss__assig__5BE2A6F2");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK__RescueAss__rescu__59063A47");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueTeamId)
                .HasConstraintName("FK__RescueAss__rescu__59FA5E80");

            entity.HasOne(d => d.Shift).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__RescueAss__shift__5AEE82B9");
        });

        modelBuilder.Entity<RescueRequest>(entity =>
        {
            entity.HasKey(e => e.RescueRequestId).HasName("PK__RescueRe__6F0FA6A5FC0E1BD3");

            entity.ToTable("RescueRequest");

            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CitizenUserId).HasColumnName("citizen_user_id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LocationImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("location_image_url");
            entity.Property(e => e.LocationLat)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("location_lat");
            entity.Property(e => e.LocationLng)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("location_lng");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_type");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UrgencyLevelId).HasColumnName("urgency_level_id");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("verified_at");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__RescueReq__area___44FF419A");

            entity.HasOne(d => d.CitizenUser).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.CitizenUserId)
                .HasConstraintName("FK__RescueReq__citiz__440B1D61");

            entity.HasOne(d => d.Status).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__RescueReq__statu__46E78A0C");

            entity.HasOne(d => d.UrgencyLevel).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.UrgencyLevelId)
                .HasConstraintName("FK__RescueReq__urgen__45F365D3");
        });

        modelBuilder.Entity<RescueShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__RescueSh__7B267220496E3152");

            entity.ToTable("RescueShift");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ClosedAt)
                .HasColumnType("datetime")
                .HasColumnName("closed_at");
            entity.Property(e => e.ClosedBy).HasColumnName("closed_by");
            entity.Property(e => e.OpenedAt)
                .HasColumnType("datetime")
                .HasColumnName("opened_at");
            entity.Property(e => e.OpenedBy).HasColumnName("opened_by");
            entity.Property(e => e.ShiftStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shift_status");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueShifts)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__RescueShi__area___5441852A");

            entity.HasOne(d => d.ClosedByNavigation).WithMany(p => p.RescueShiftClosedByNavigations)
                .HasForeignKey(d => d.ClosedBy)
                .HasConstraintName("FK__RescueShi__close__5629CD9C");

            entity.HasOne(d => d.OpenedByNavigation).WithMany(p => p.RescueShiftOpenedByNavigations)
                .HasForeignKey(d => d.OpenedBy)
                .HasConstraintName("FK__RescueShi__opene__5535A963");
        });

        modelBuilder.Entity<RescueTeam>(entity =>
        {
            entity.HasKey(e => e.RescueTeamId).HasName("PK__RescueTe__4E49BEED0F863A80");

            entity.ToTable("RescueTeam");

            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("team_name");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueTeams)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__RescueTea__area___4D94879B");

            entity.HasMany(d => d.Vehicles).WithMany(p => p.RescueTeams)
                .UsingEntity<Dictionary<string, object>>(
                    "RescueTeamVehicle",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RescueTea__vehic__619B8048"),
                    l => l.HasOne<RescueTeam>().WithMany()
                        .HasForeignKey("RescueTeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RescueTea__rescu__60A75C0F"),
                    j =>
                    {
                        j.HasKey("RescueTeamId", "VehicleId").HasName("PK__RescueTe__4160F951BDBD735B");
                        j.ToTable("RescueTeamVehicle");
                        j.IndexerProperty<int>("RescueTeamId").HasColumnName("rescue_team_id");
                        j.IndexerProperty<int>("VehicleId").HasColumnName("vehicle_id");
                    });
        });

        modelBuilder.Entity<RescueTeamMember>(entity =>
        {
            entity.HasKey(e => new { e.RescueTeamId, e.UserId }).HasName("PK__RescueTe__A5D25D9DAA2079F9");

            entity.ToTable("RescueTeamMember");

            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleInTeam)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role_in_team");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.RescueTeamMembers)
                .HasForeignKey(d => d.RescueTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RescueTea__rescu__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.RescueTeamMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RescueTea__user___5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CC08C34E5D");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<UrgencyLevel>(entity =>
        {
            entity.HasKey(e => e.UrgencyLevelId).HasName("PK__UrgencyL__D320909777207A9F");

            entity.ToTable("UrgencyLevel");

            entity.Property(e => e.UrgencyLevelId).HasColumnName("urgency_level_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LevelName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("level_name");
            entity.Property(e => e.SlaMinutes).HasColumnName("sla_minutes");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__F2947BC1E4F2751C");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vehicle_name");
            entity.Property(e => e.VehicleStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vehicle_status");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vehicle_type");
        });

        modelBuilder.Entity<WarehouseInventory>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ReliefItemId }).HasName("PK__Warehous__A4CB4BEBE9C58132");

            entity.ToTable("WarehouseInventory");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.WarehouseInventories)
                .HasForeignKey(d => d.ReliefItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warehouse__relie__6A30C649");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseInventories)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warehouse__wareh__693CA210");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
