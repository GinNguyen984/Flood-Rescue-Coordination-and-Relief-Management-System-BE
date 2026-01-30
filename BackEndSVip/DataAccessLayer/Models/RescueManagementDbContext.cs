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

    public virtual DbSet<PeriodicAidBeneficiary> PeriodicAidBeneficiaries { get; set; }

    public virtual DbSet<PeriodicAidCampaign> PeriodicAidCampaigns { get; set; }

    public virtual DbSet<PeriodicAidDistribution> PeriodicAidDistributions { get; set; }

    public virtual DbSet<PeriodicAidDistributionDetail> PeriodicAidDistributionDetails { get; set; }

    public virtual DbSet<PeriodicAidSupplyPlan> PeriodicAidSupplyPlans { get; set; }

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
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__B74DF4E2A79A2041");

            entity.ToTable("Attachment");

            entity.Property(e => e.AttachmentId)
                .ValueGeneratedNever()
                .HasColumnName("attachment_id");
            entity.Property(e => e.FileType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_type");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_url");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.UploadedAt)
                .HasColumnType("datetime")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK_Attach_Request");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK_Attach_User");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__5AF33E33DAB6F94B");

            entity.ToTable("AuditLog");

            entity.Property(e => e.AuditId)
                .ValueGeneratedNever()
                .HasColumnName("audit_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.ActionAt)
                .HasColumnType("datetime")
                .HasColumnName("action_at");
            entity.Property(e => e.ActorId).HasColumnName("actor_id");
            entity.Property(e => e.ActorRole)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("actor_role");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("entity_name");

            entity.HasOne(d => d.Actor).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("FK_Audit_User");
        });

        modelBuilder.Entity<GeographicArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Geograph__985D6D6B1F4E3051");

            entity.ToTable("GeographicArea");

            entity.Property(e => e.AreaId)
                .ValueGeneratedNever()
                .HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area_name");
            entity.Property(e => e.ParentAreaId).HasColumnName("parent_area_id");

            entity.HasOne(d => d.ParentArea).WithMany(p => p.InverseParentArea)
                .HasForeignKey(d => d.ParentAreaId)
                .HasConstraintName("FK_Geo_Parent");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionId).HasName("PK__Inventor__C807F3E6A5A4A293");

            entity.ToTable("InventoryTransaction");

            entity.Property(e => e.InventoryTransactionId)
                .ValueGeneratedNever()
                .HasColumnName("inventory_transaction_id");
            entity.Property(e => e.ConfirmedAt)
                .HasColumnType("datetime")
                .HasColumnName("confirmed_at");
            entity.Property(e => e.ConfirmedBy).HasColumnName("confirmed_by");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("transaction_type");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.InventoryTransactionConfirmedByNavigations)
                .HasForeignKey(d => d.ConfirmedBy)
                .HasConstraintName("FK_Inv_Confirm");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryTransactionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Inv_Create");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK_Inv_Request");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_Inv_Warehouse");
        });

        modelBuilder.Entity<PeriodicAidBeneficiary>(entity =>
        {
            entity.HasKey(e => e.BeneficiaryId).HasName("PK__Periodic__44CCFEFFAD4E38FA");

            entity.ToTable("PeriodicAidBeneficiary");

            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.CitizenUserId).HasColumnName("citizen_user_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.HouseholdSize).HasColumnName("household_size");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PriorityLevel).HasColumnName("priority_level");
            entity.Property(e => e.SelectedAt)
                .HasColumnType("datetime")
                .HasColumnName("selected_at");
            entity.Property(e => e.SelectedByAdminId).HasColumnName("selected_by_admin_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TargetGroup)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("target_group");

            entity.HasOne(d => d.Area).WithMany(p => p.PeriodicAidBeneficiaries)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_PAB_Area");

            entity.HasOne(d => d.Campaign).WithMany(p => p.PeriodicAidBeneficiaries)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("FK_PAB_Campaign");

            entity.HasOne(d => d.CitizenUser).WithMany(p => p.PeriodicAidBeneficiaryCitizenUsers)
                .HasForeignKey(d => d.CitizenUserId)
                .HasConstraintName("FK_PAB_User");

            entity.HasOne(d => d.SelectedByAdmin).WithMany(p => p.PeriodicAidBeneficiarySelectedByAdmins)
                .HasForeignKey(d => d.SelectedByAdminId)
                .HasConstraintName("FK_PAB_Admin");
        });

        modelBuilder.Entity<PeriodicAidCampaign>(entity =>
        {
            entity.HasKey(e => e.CampaignId).HasName("PK__Periodic__905B681C1899F092");

            entity.ToTable("PeriodicAidCampaign");

            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CampaignName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("campaign_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByAdminId).HasColumnName("created_by_admin_id");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<PeriodicAidDistribution>(entity =>
        {
            entity.HasKey(e => e.DistributionId).HasName("PK__Periodic__330512D4A2A09D21");

            entity.ToTable("PeriodicAidDistribution");

            entity.Property(e => e.DistributionId).HasColumnName("distribution_id");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.DistributedAt)
                .HasColumnType("datetime")
                .HasColumnName("distributed_at");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Campaign).WithMany(p => p.PeriodicAidDistributions)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("FK_PAD_Campaign");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.PeriodicAidDistributions)
                .HasForeignKey(d => d.RescueTeamId)
                .HasConstraintName("FK_PAD_Team");
        });

        modelBuilder.Entity<PeriodicAidDistributionDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__Periodic__38E9A224AA9766ED");

            entity.ToTable("PeriodicAidDistributionDetail");

            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.DistributionId).HasColumnName("distribution_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.PeriodicAidDistributionDetails)
                .HasForeignKey(d => d.BeneficiaryId)
                .HasConstraintName("FK_PADD_Beneficiary");

            entity.HasOne(d => d.Distribution).WithMany(p => p.PeriodicAidDistributionDetails)
                .HasForeignKey(d => d.DistributionId)
                .HasConstraintName("FK_PADD_Distribution");
        });

        modelBuilder.Entity<PeriodicAidSupplyPlan>(entity =>
        {
            entity.HasKey(e => e.SupplyPlanId).HasName("PK__Periodic__0382F5DDFE34D505");

            entity.ToTable("PeriodicAidSupplyPlan");

            entity.Property(e => e.SupplyPlanId).HasColumnName("supply_plan_id");
            entity.Property(e => e.ApprovedQuantity).HasColumnName("approved_quantity");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByManagerId).HasColumnName("created_by_manager_id");
            entity.Property(e => e.PlannedQuantity).HasColumnName("planned_quantity");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");

            entity.HasOne(d => d.Campaign).WithMany(p => p.PeriodicAidSupplyPlans)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("FK_PASP_Campaign");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.PeriodicAidSupplyPlans)
                .HasForeignKey(d => d.ReliefItemId)
                .HasConstraintName("FK_PASP_Item");
        });

        modelBuilder.Entity<ReliefDistribution>(entity =>
        {
            entity.HasKey(e => e.DistributionId).HasName("PK__ReliefDi__330512D479007793");

            entity.ToTable("ReliefDistribution");

            entity.Property(e => e.DistributionId)
                .ValueGeneratedNever()
                .HasColumnName("distribution_id");
            entity.Property(e => e.DistributedAt)
                .HasColumnType("datetime")
                .HasColumnName("distributed_at");
            entity.Property(e => e.DistributionStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("distribution_status");
            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventory_transaction_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReliefItemId).HasColumnName("relief_item_id");

            entity.HasOne(d => d.InventoryTransaction).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.InventoryTransactionId)
                .HasConstraintName("FK_Dis_Transaction");

            entity.HasOne(d => d.ReliefItem).WithMany(p => p.ReliefDistributions)
                .HasForeignKey(d => d.ReliefItemId)
                .HasConstraintName("FK_Dis_Item");
        });

        modelBuilder.Entity<ReliefItem>(entity =>
        {
            entity.HasKey(e => e.ReliefItemId).HasName("PK__ReliefIt__784AD54C8B4D3FA7");

            entity.ToTable("ReliefItem");

            entity.Property(e => e.ReliefItemId)
                .ValueGeneratedNever()
                .HasColumnName("relief_item_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<ReliefWarehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__ReliefWa__734FE6BF7D3CBDAF");

            entity.ToTable("ReliefWarehouse");

            entity.Property(e => e.WarehouseId)
                .ValueGeneratedNever()
                .HasColumnName("warehouse_id");
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
                .HasConstraintName("FK_Warehouse_Area");
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__RequestL__9E2397E0CAB271A6");

            entity.ToTable("RequestLog");

            entity.Property(e => e.LogId)
                .ValueGeneratedNever()
                .HasColumnName("log_id");
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
                .HasConstraintName("FK_Log_User");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK_Log_Request");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__RequestS__3683B531381C9BE1");

            entity.ToTable("RequestStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsFinal).HasColumnName("is_final");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<RequestVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__RequestV__24F17969BC7FDD40");

            entity.ToTable("RequestVerification");

            entity.Property(e => e.VerificationId)
                .ValueGeneratedNever()
                .HasColumnName("verification_id");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.VerificationStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("verification_status");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("verified_at");
            entity.Property(e => e.VerifiedBy).HasColumnName("verified_by");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK_Verify_Request");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.RequestVerifications)
                .HasForeignKey(d => d.VerifiedBy)
                .HasConstraintName("FK_Verify_User");
        });

        modelBuilder.Entity<RescueAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__RescueAs__DA89181494CDEEC1");

            entity.ToTable("RescueAssignment");

            entity.Property(e => e.AssignmentId)
                .ValueGeneratedNever()
                .HasColumnName("assignment_id");
            entity.Property(e => e.AssignedAt)
                .HasColumnType("datetime")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.AssignmentStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assignment_status");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.RejectReason).HasColumnName("reject_reason");
            entity.Property(e => e.RescueRequestId).HasColumnName("rescue_request_id");
            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("FK_Assign_User");

            entity.HasOne(d => d.RescueRequest).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueRequestId)
                .HasConstraintName("FK_Assign_Request");

            entity.HasOne(d => d.RescueTeam).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.RescueTeamId)
                .HasConstraintName("FK_Assign_Team");

            entity.HasOne(d => d.Shift).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_Assign_Shift");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.RescueAssignments)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK_Assign_Vehicle");
        });

        modelBuilder.Entity<RescueRequest>(entity =>
        {
            entity.HasKey(e => e.RescueRequestId).HasName("PK__RescueRe__6F0FA6A545AC7789");

            entity.ToTable("RescueRequest");

            entity.Property(e => e.RescueRequestId)
                .ValueGeneratedNever()
                .HasColumnName("rescue_request_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CitizenUserId).HasColumnName("citizen_user_id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LocationImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location_image_url");
            entity.Property(e => e.LocationLat)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("location_lat");
            entity.Property(e => e.LocationLng)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("location_lng");
            entity.Property(e => e.RequestType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_type");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UrgencyLevelId).HasColumnName("urgency_level_id");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("verified_at");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_Request_Area");

            entity.HasOne(d => d.CitizenUser).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.CitizenUserId)
                .HasConstraintName("FK_Request_User");

            entity.HasOne(d => d.Status).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Request_Status");

            entity.HasOne(d => d.UrgencyLevel).WithMany(p => p.RescueRequests)
                .HasForeignKey(d => d.UrgencyLevelId)
                .HasConstraintName("FK_Request_Urgency");
        });

        modelBuilder.Entity<RescueShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__RescueSh__7B267220B3825991");

            entity.ToTable("RescueShift");

            entity.Property(e => e.ShiftId)
                .ValueGeneratedNever()
                .HasColumnName("shift_id");
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
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("shift_status");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueShifts)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_Shift_Area");

            entity.HasOne(d => d.ClosedByNavigation).WithMany(p => p.RescueShiftClosedByNavigations)
                .HasForeignKey(d => d.ClosedBy)
                .HasConstraintName("FK_Shift_Close");

            entity.HasOne(d => d.OpenedByNavigation).WithMany(p => p.RescueShiftOpenedByNavigations)
                .HasForeignKey(d => d.OpenedBy)
                .HasConstraintName("FK_Shift_Open");
        });

        modelBuilder.Entity<RescueTeam>(entity =>
        {
            entity.HasKey(e => e.RescueTeamId).HasName("PK__RescueTe__4E49BEED72E0D9E9");

            entity.ToTable("RescueTeam");

            entity.Property(e => e.RescueTeamId)
                .ValueGeneratedNever()
                .HasColumnName("rescue_team_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("team_name");

            entity.HasOne(d => d.Area).WithMany(p => p.RescueTeams)
                .HasForeignKey(d => d.AreaId)
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
                        j.HasKey("RescueTeamId", "VehicleId").HasName("PK__RescueTe__4160F951D1441075");
                        j.ToTable("RescueTeamVehicle");
                        j.IndexerProperty<int>("RescueTeamId").HasColumnName("rescue_team_id");
                        j.IndexerProperty<int>("VehicleId").HasColumnName("vehicle_id");
                    });
        });

        modelBuilder.Entity<RescueTeamMember>(entity =>
        {
            entity.HasKey(e => new { e.RescueTeamId, e.UserId }).HasName("PK__RescueTe__A5D25D9D5DFDCB37");

            entity.ToTable("RescueTeamMember");

            entity.Property(e => e.RescueTeamId).HasColumnName("rescue_team_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleInTeam)
                .HasMaxLength(255)
                .IsUnicode(false)
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
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CCCAE2155D");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<UrgencyLevel>(entity =>
        {
            entity.HasKey(e => e.UrgencyLevelId).HasName("PK__UrgencyL__D320909742A14456");

            entity.ToTable("UrgencyLevel");

            entity.Property(e => e.UrgencyLevelId)
                .ValueGeneratedNever()
                .HasColumnName("urgency_level_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LevelName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("level_name");
            entity.Property(e => e.SlaMinutes).HasColumnName("sla_minutes");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370FFC986790");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
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
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Users)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_User_Area");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__F2947BC121D98E04");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId)
                .ValueGeneratedNever()
                .HasColumnName("vehicle_id");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vehicle_name");
            entity.Property(e => e.VehicleStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vehicle_status");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vehicle_type");
        });

        modelBuilder.Entity<WarehouseInventory>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ReliefItemId }).HasName("PK__Warehous__A4CB4BEBAB874A71");

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
