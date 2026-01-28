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

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<WarehouseInventory> WarehouseInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=database.purintech.id.vn;user=etoet;password=etoet;Database=RescueManagementDB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__B74DF4E20869D8B6");

            entity.ToTable("Attachment");

            entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .HasColumnName("file_type");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(500)
                .HasColumnName("file_url");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.RescueRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attachment_Request");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attachment_User");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__5AF33E33CDBB9986");

            entity.ToTable("AuditLog");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.ActionAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("action_at");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.ActorRole)
                .HasMaxLength(100)
                .HasColumnName("actor_role");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityName)
                .HasMaxLength(100)
                .HasColumnName("entity_name");
        });

        modelBuilder.Entity<GeographicArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Geograph__985D6D6B0F7C6140");

            entity.ToTable("GeographicArea");

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(255)
                .HasColumnName("area_name");
            entity.Property(e => e.ParentAreaId).HasColumnName("parent_area_id");

            entity.HasOne(d => d.ParentArea).WithMany(p => p.InverseParentArea)
                .HasForeignKey(d => d.ParentAreaId)
                .HasConstraintName("FK_GeographicArea_Parent");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionId).HasName("PK__Inventor__C807F3E6946C823D");

            entity.ToTable("InventoryTransaction");

            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventory_transaction_id");
            entity.Property(e => e.ConfirmedAt).HasColumnName("confirmed_at");
            entity.Property(e => e.ConfirmedBy).HasColumnName("confirmed_by");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .HasColumnName("transaction_type");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.InventoryTransactionConfirmedByNavigations)
                .HasForeignKey(d => d.ConfirmedBy)
                .HasConstraintName("FK_Transaction_ConfirmedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransactionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_CreatedBy");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.RescueRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Request");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Warehouse");
        });

        modelBuilder.Entity<ReliefDistribution>(entity =>
        {
            entity.HasKey(e => e.DistributionId).HasName("PK__ReliefDi__330512D4D0DF52FD");

            entity.ToTable("ReliefDistribution");

            entity.Property(e => e.DistributionId).HasColumnName("distribution_id");
            entity.Property(e => e.DistributedAt).HasColumnName("distributed_at");
            entity.Property(e => e.DistributionStatus)
                .HasMaxLength(50)
                .HasColumnName("distribution_status");
            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventory_transaction_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.InventoryTransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Transaction");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.ReliefItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Item");
        });

        modelBuilder.Entity<ReliefItem>(entity =>
        {
            entity.HasKey(e => e.ReliefItemId).HasName("PK__ReliefIt__784AD54CF643736C");

            entity.ToTable("ReliefItem");

            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .HasColumnName("item_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<ReliefWarehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__ReliefWa__734FE6BF761E021C");

            entity.ToTable("ReliefWarehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.LocationDescription)
                .HasMaxLength(255)
                .HasColumnName("location_description");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(255)
                .HasColumnName("warehouse_name");

            entity.HasOne(d => d.Area).WithMany(p => p.ReliefWarehouses)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Area");
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__RequestL__9E2397E024457F06");

            entity.ToTable("RequestLog");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.PerformedBy).HasColumnName("performed_by");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");

            entity.HasOne(d => d.PerformedByNavigation).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.PerformedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestLog_User");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.RescueRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestLog_Request");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__RequestS__3683B5316D4F8832");

            entity.ToTable("RequestStatus");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsFinal).HasColumnName("is_final");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<RequestVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__RequestV__24F17969BC4902D5");

            entity.ToTable("RequestVerification");

            entity.Property(e => e.VerificationId).HasColumnName("verification_id");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.VerificationStatus)
                .HasMaxLength(50)
                .HasColumnName("verification_status");
            entity.Property(e => e.VerifiedAt).HasColumnName("verified_at");
            entity.Property(e => e.VerifiedBy).HasColumnName("verified_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.RescueRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Verification_Request");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.VerifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Verification_User");
        });

        modelBuilder.Entity<RescueAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__RescueAs__DA8918144BB1AAD8");

            entity.ToTable("RescueAssignment");

            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.AssignmentStatus)
                .HasMaxLength(50)
                .HasColumnName("assignment_status");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.RejectReason).HasColumnName("reject_reason");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.ShiftId).HasColumnName("shift_id");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.AssignedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_AssignedBy");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Request");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Team");

            entity.HasOne(d => d.Shift).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignment_Shift");
        });

        modelBuilder.Entity<RescueRequest>(entity =>
        {
            entity.HasKey(e => e.RescueRequestId).HasName("PK__RescueRe__6F0FA6A5CB375170");

            entity.ToTable("RescueRequest");

            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CitizenUserId).HasColumnName("citizen_user_id");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.LocationLat)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("location_lat");
            entity.Property(e => e.LocationLng)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("location_lng");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .HasColumnName("request_type");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UrgencyLevelId).HasColumnName("urgency_level_id");
            entity.Property(e => e.VerifiedAt).HasColumnName("verified_at");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Area");

            entity.HasOne(d => d.CitizenUser).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.CitizenUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_User");

            entity.HasOne(d => d.Status).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Status");

            entity.HasOne(d => d.UrgencyLevel).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.UrgencyLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Urgency");
        });

        modelBuilder.Entity<RescueShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__RescueSh__7B267220C81BC352");

            entity.ToTable("RescueShift");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ClosedAt).HasColumnName("closed_at");
            entity.Property(e => e.ClosedBy).HasColumnName("closed_by");
            entity.Property(e => e.OpenedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("opened_at");
            entity.Property(e => e.OpenedBy).HasColumnName("opened_by");
            entity.Property(e => e.ShiftStatus)
                .HasMaxLength(50)
                .HasColumnName("shift_status");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueShifts)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shift_Area");

            entity.HasOne(d => d.ClosedByNavigation).WithMany(p => p.RescueShiftClosedByNavigations)
                .HasForeignKey(d => d.ClosedBy)
                .HasConstraintName("FK_Shift_ClosedBy");

            entity.HasOne(d => d.OpenedByNavigation).WithMany(p => p.RescueShiftOpenedByNavigations)
                .HasForeignKey(d => d.OpenedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shift_OpenedBy");
        });

        modelBuilder.Entity<RescueTeam>(entity =>
        {
            entity.HasKey(e => e.RescueTeamId).HasName("PK__RescueTe__4E49BEED7EC45DD4");

            entity.ToTable("RescueTeam");

            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(255)
                .HasColumnName("team_name");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueTeams)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Area");

            entity.HasMany(d => d.Vehicles).WithMany(p => p.RescueTeams)
                .UsingEntity<Dictionary<string, object>>(
                    "RescueTeamVehicle",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeamVehicle_Vehicle"),
                    l => l.HasOne<RescueTeam>().WithMany()
                        .HasForeignKey("RescueTeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeamVehicle_Team"),
                    j =>
                    {
                        j.HasKey("RescueTeamId", "VehicleId").HasName("PK_TeamVehicle");
                        j.ToTable("RescueTeamVehicle");
                        j.IndexerProperty<int>("RescueTeamId").HasColumnName("rescue_team_id");
                        j.IndexerProperty<int>("VehicleId").HasColumnName("vehicle_id");
                    });
        });

        modelBuilder.Entity<RescueTeamMember>(entity =>
        {
            entity.HasKey(e => new { e.RescueTeamId, e.UserId }).HasName("PK_TeamMember");

            entity.ToTable("RescueTeamMember");

            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleInTeam)
                .HasMaxLength(100)
                .HasColumnName("role_in_team");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.RescueTeamMembers)
                .HasForeignKey(d => d.RescueTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMember_Team");

            entity.HasOne(d => d.User).WithMany(p => p.RescueTeamMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMember_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CC39B6A2EA");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<UrgencyLevel>(entity =>
        {
            entity.HasKey(e => e.UrgencyLevelId).HasName("PK__UrgencyL__D3209097AC7A7511");

            entity.ToTable("UrgencyLevel");

            entity.Property(e => e.UrgencyLevelId).HasColumnName("urgency_level_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LevelName)
                .HasMaxLength(100)
                .HasColumnName("level_name");
            entity.Property(e => e.SlaMinutes).HasColumnName("sla_minutes");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370F5C5CFA7A");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Users)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Area");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__F2947BC1DB34F304");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(255)
                .HasColumnName("vehicle_name");
            entity.Property(e => e.VehicleStatus)
                .HasMaxLength(50)
                .HasColumnName("vehicle_status");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(100)
                .HasColumnName("vehicle_type");
        });

        modelBuilder.Entity<WarehouseInventory>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ReliefItemId });

            entity.ToTable("WarehouseInventory");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.WarehouseInventories)
                .HasForeignKey(d => d.ReliefItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Item");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseInventories)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
