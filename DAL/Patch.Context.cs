﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class patchEntities : DbContext
    {
        public patchEntities()
            : base("name=patchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<achievement> achievements { get; set; }
        public DbSet<achievement_locale> achievement_locale { get; set; }
        public DbSet<anim_kit> anim_kit { get; set; }
        public DbSet<area_group_member> area_group_member { get; set; }
        public DbSet<area_table> area_table { get; set; }
        public DbSet<area_table_locale> area_table_locale { get; set; }
        public DbSet<area_trigger> area_trigger { get; set; }
        public DbSet<armor_location> armor_location { get; set; }
        public DbSet<artifact> artifacts { get; set; }
        public DbSet<artifact_appearance> artifact_appearance { get; set; }
        public DbSet<artifact_appearance_locale> artifact_appearance_locale { get; set; }
        public DbSet<artifact_appearance_set> artifact_appearance_set { get; set; }
        public DbSet<artifact_appearance_set_locale> artifact_appearance_set_locale { get; set; }
        public DbSet<artifact_category> artifact_category { get; set; }
        public DbSet<artifact_locale> artifact_locale { get; set; }
        public DbSet<artifact_power> artifact_power { get; set; }
        public DbSet<artifact_power_link> artifact_power_link { get; set; }
        public DbSet<artifact_power_picker> artifact_power_picker { get; set; }
        public DbSet<artifact_power_rank> artifact_power_rank { get; set; }
        public DbSet<artifact_quest_xp> artifact_quest_xp { get; set; }
        public DbSet<auction_house> auction_house { get; set; }
        public DbSet<auction_house_locale> auction_house_locale { get; set; }
        public DbSet<bank_bag_slot_prices> bank_bag_slot_prices { get; set; }
        public DbSet<banned_addons> banned_addons { get; set; }
        public DbSet<barber_shop_style> barber_shop_style { get; set; }
        public DbSet<barber_shop_style_locale> barber_shop_style_locale { get; set; }
        public DbSet<battle_pet_breed_quality> battle_pet_breed_quality { get; set; }
        public DbSet<battle_pet_breed_state> battle_pet_breed_state { get; set; }
        public DbSet<battle_pet_species> battle_pet_species { get; set; }
        public DbSet<battle_pet_species_locale> battle_pet_species_locale { get; set; }
        public DbSet<battle_pet_species_state> battle_pet_species_state { get; set; }
        public DbSet<battlemaster_list> battlemaster_list { get; set; }
        public DbSet<battlemaster_list_locale> battlemaster_list_locale { get; set; }
        public DbSet<broadcast_text> broadcast_text { get; set; }
        public DbSet<broadcast_text_locale> broadcast_text_locale { get; set; }
        public DbSet<char_base_section> char_base_section { get; set; }
        public DbSet<char_sections> char_sections { get; set; }
        public DbSet<char_start_outfit> char_start_outfit { get; set; }
        public DbSet<char_titles> char_titles { get; set; }
        public DbSet<char_titles_locale> char_titles_locale { get; set; }
        public DbSet<character_facial_hair_styles> character_facial_hair_styles { get; set; }
        public DbSet<chat_channels> chat_channels { get; set; }
        public DbSet<chat_channels_locale> chat_channels_locale { get; set; }
        public DbSet<chr_classes> chr_classes { get; set; }
        public DbSet<chr_classes_locale> chr_classes_locale { get; set; }
        public DbSet<chr_classes_x_power_types> chr_classes_x_power_types { get; set; }
        public DbSet<chr_races> chr_races { get; set; }
        public DbSet<chr_races_locale> chr_races_locale { get; set; }
        public DbSet<chr_specialization> chr_specialization { get; set; }
        public DbSet<chr_specialization_locale> chr_specialization_locale { get; set; }
        public DbSet<cinematic_camera> cinematic_camera { get; set; }
        public DbSet<cinematic_sequences> cinematic_sequences { get; set; }
        public DbSet<conversation_line> conversation_line { get; set; }
        public DbSet<creature> creatures { get; set; }
        public DbSet<creature_difficulty> creature_difficulty { get; set; }
        public DbSet<creature_display_info> creature_display_info { get; set; }
        public DbSet<creature_display_info_extra> creature_display_info_extra { get; set; }
        public DbSet<creature_family> creature_family { get; set; }
        public DbSet<creature_family_locale> creature_family_locale { get; set; }
        public DbSet<creature_model_data> creature_model_data { get; set; }
        public DbSet<creature_type> creature_type { get; set; }
        public DbSet<creature_type_locale> creature_type_locale { get; set; }
        public DbSet<criterion> criteria { get; set; }
        public DbSet<criteria_tree> criteria_tree { get; set; }
        public DbSet<criteria_tree_locale> criteria_tree_locale { get; set; }
        public DbSet<currency_types> currency_types { get; set; }
        public DbSet<currency_types_locale> currency_types_locale { get; set; }
        public DbSet<curve> curves { get; set; }
        public DbSet<curve_point> curve_point { get; set; }
        public DbSet<destructible_model_data> destructible_model_data { get; set; }
        public DbSet<difficulty> difficulties { get; set; }
        public DbSet<difficulty_locale> difficulty_locale { get; set; }
        public DbSet<dungeon_encounter> dungeon_encounter { get; set; }
        public DbSet<dungeon_encounter_locale> dungeon_encounter_locale { get; set; }
        public DbSet<durability_costs> durability_costs { get; set; }
        public DbSet<durability_quality> durability_quality { get; set; }
        public DbSet<emote> emotes { get; set; }
        public DbSet<emotes_text> emotes_text { get; set; }
        public DbSet<emotes_text_locale> emotes_text_locale { get; set; }
        public DbSet<emotes_text_sound> emotes_text_sound { get; set; }
        public DbSet<faction> factions { get; set; }
        public DbSet<faction_locale> faction_locale { get; set; }
        public DbSet<faction_template> faction_template { get; set; }
        public DbSet<gameobject_display_info> gameobject_display_info { get; set; }
        public DbSet<gameobject> gameobjects { get; set; }
        public DbSet<gameobjects_locale> gameobjects_locale { get; set; }
        public DbSet<garr_ability> garr_ability { get; set; }
        public DbSet<garr_ability_locale> garr_ability_locale { get; set; }
        public DbSet<garr_building> garr_building { get; set; }
        public DbSet<garr_building_locale> garr_building_locale { get; set; }
        public DbSet<garr_building_plot_inst> garr_building_plot_inst { get; set; }
        public DbSet<garr_class_spec> garr_class_spec { get; set; }
        public DbSet<garr_class_spec_locale> garr_class_spec_locale { get; set; }
        public DbSet<garr_follower> garr_follower { get; set; }
        public DbSet<garr_follower_locale> garr_follower_locale { get; set; }
        public DbSet<garr_follower_x_ability> garr_follower_x_ability { get; set; }
        public DbSet<garr_plot> garr_plot { get; set; }
        public DbSet<garr_plot_building> garr_plot_building { get; set; }
        public DbSet<garr_plot_instance> garr_plot_instance { get; set; }
        public DbSet<garr_plot_instance_locale> garr_plot_instance_locale { get; set; }
        public DbSet<garr_plot_locale> garr_plot_locale { get; set; }
        public DbSet<garr_site_level> garr_site_level { get; set; }
        public DbSet<garr_site_level_plot_inst> garr_site_level_plot_inst { get; set; }
        public DbSet<gem_properties> gem_properties { get; set; }
        public DbSet<glyph_bindable_spell> glyph_bindable_spell { get; set; }
        public DbSet<glyph_properties> glyph_properties { get; set; }
        public DbSet<glyph_required_spec> glyph_required_spec { get; set; }
        public DbSet<guild_color_background> guild_color_background { get; set; }
        public DbSet<guild_color_border> guild_color_border { get; set; }
        public DbSet<guild_color_emblem> guild_color_emblem { get; set; }
        public DbSet<guild_perk_spells> guild_perk_spells { get; set; }
        public DbSet<heirloom> heirlooms { get; set; }
        public DbSet<heirloom_locale> heirloom_locale { get; set; }
        public DbSet<holiday> holidays { get; set; }
        public DbSet<hotfix_data> hotfix_data { get; set; }
        public DbSet<import_price_armor> import_price_armor { get; set; }
        public DbSet<import_price_quality> import_price_quality { get; set; }
        public DbSet<import_price_shield> import_price_shield { get; set; }
        public DbSet<import_price_weapon> import_price_weapon { get; set; }
        public DbSet<item> items { get; set; }
        public DbSet<item_appearance> item_appearance { get; set; }
        public DbSet<item_armor_quality> item_armor_quality { get; set; }
        public DbSet<item_armor_shield> item_armor_shield { get; set; }
        public DbSet<item_armor_total> item_armor_total { get; set; }
        public DbSet<item_bag_family> item_bag_family { get; set; }
        public DbSet<item_bag_family_locale> item_bag_family_locale { get; set; }
        public DbSet<item_bonus> item_bonus { get; set; }
        public DbSet<item_bonus_list_level_delta> item_bonus_list_level_delta { get; set; }
        public DbSet<item_bonus_tree_node> item_bonus_tree_node { get; set; }
        public DbSet<item_child_equipment> item_child_equipment { get; set; }
        public DbSet<item_class> item_class { get; set; }
        public DbSet<item_class_locale> item_class_locale { get; set; }
        public DbSet<item_currency_cost> item_currency_cost { get; set; }
        public DbSet<item_damage_ammo> item_damage_ammo { get; set; }
        public DbSet<item_damage_one_hand> item_damage_one_hand { get; set; }
        public DbSet<item_damage_one_hand_caster> item_damage_one_hand_caster { get; set; }
        public DbSet<item_damage_two_hand> item_damage_two_hand { get; set; }
        public DbSet<item_damage_two_hand_caster> item_damage_two_hand_caster { get; set; }
        public DbSet<item_disenchant_loot> item_disenchant_loot { get; set; }
        public DbSet<item_effect> item_effect { get; set; }
        public DbSet<item_extended_cost> item_extended_cost { get; set; }
        public DbSet<item_level_selector> item_level_selector { get; set; }
        public DbSet<item_limit_category> item_limit_category { get; set; }
        public DbSet<item_limit_category_locale> item_limit_category_locale { get; set; }
        public DbSet<item_modified_appearance> item_modified_appearance { get; set; }
        public DbSet<item_price_base> item_price_base { get; set; }
        public DbSet<item_random_properties> item_random_properties { get; set; }
        public DbSet<item_random_properties_locale> item_random_properties_locale { get; set; }
        public DbSet<item_random_suffix> item_random_suffix { get; set; }
        public DbSet<item_random_suffix_locale> item_random_suffix_locale { get; set; }
        public DbSet<item_search_name> item_search_name { get; set; }
        public DbSet<item_search_name_locale> item_search_name_locale { get; set; }
        public DbSet<item_set> item_set { get; set; }
        public DbSet<item_set_locale> item_set_locale { get; set; }
        public DbSet<item_set_spell> item_set_spell { get; set; }
        public DbSet<item_sparse> item_sparse { get; set; }
        public DbSet<item_sparse_locale> item_sparse_locale { get; set; }
        public DbSet<item_spec> item_spec { get; set; }
        public DbSet<item_spec_override> item_spec_override { get; set; }
        public DbSet<item_upgrade> item_upgrade { get; set; }
        public DbSet<item_x_bonus_tree> item_x_bonus_tree { get; set; }
        public DbSet<key_chain> key_chain { get; set; }
        public DbSet<lfg_dungeons> lfg_dungeons { get; set; }
        public DbSet<lfg_dungeons_locale> lfg_dungeons_locale { get; set; }
        public DbSet<light> lights { get; set; }
        public DbSet<liquid_type> liquid_type { get; set; }
        public DbSet<liquid_type_locale> liquid_type_locale { get; set; }
        public DbSet<@lock> locks { get; set; }
        public DbSet<mail_template> mail_template { get; set; }
        public DbSet<mail_template_locale> mail_template_locale { get; set; }
        public DbSet<map> maps { get; set; }
        public DbSet<map_difficulty> map_difficulty { get; set; }
        public DbSet<map_difficulty_locale> map_difficulty_locale { get; set; }
        public DbSet<map_locale> map_locale { get; set; }
        public DbSet<modifier_tree> modifier_tree { get; set; }
        public DbSet<mount> mounts { get; set; }
        public DbSet<mount_capability> mount_capability { get; set; }
        public DbSet<mount_locale> mount_locale { get; set; }
        public DbSet<mount_type_x_capability> mount_type_x_capability { get; set; }
        public DbSet<mount_x_display> mount_x_display { get; set; }
        public DbSet<movie> movies { get; set; }
        public DbSet<name_gen> name_gen { get; set; }
        public DbSet<name_gen_locale> name_gen_locale { get; set; }
        public DbSet<names_profanity> names_profanity { get; set; }
        public DbSet<names_reserved> names_reserved { get; set; }
        public DbSet<names_reserved_locale> names_reserved_locale { get; set; }
        public DbSet<override_spell_data> override_spell_data { get; set; }
        public DbSet<phase> phases { get; set; }
        public DbSet<phase_x_phase_group> phase_x_phase_group { get; set; }
        public DbSet<player_condition> player_condition { get; set; }
        public DbSet<player_condition_locale> player_condition_locale { get; set; }
        public DbSet<power_display> power_display { get; set; }
        public DbSet<power_type> power_type { get; set; }
        public DbSet<prestige_level_info> prestige_level_info { get; set; }
        public DbSet<prestige_level_info_locale> prestige_level_info_locale { get; set; }
        public DbSet<pvp_difficulty> pvp_difficulty { get; set; }
        public DbSet<pvp_reward> pvp_reward { get; set; }
        public DbSet<quest_faction_reward> quest_faction_reward { get; set; }
        public DbSet<quest_money_reward> quest_money_reward { get; set; }
        public DbSet<quest_package_item> quest_package_item { get; set; }
        public DbSet<quest_sort> quest_sort { get; set; }
        public DbSet<quest_sort_locale> quest_sort_locale { get; set; }
        public DbSet<quest_v2> quest_v2 { get; set; }
        public DbSet<quest_xp> quest_xp { get; set; }
        public DbSet<rand_prop_points> rand_prop_points { get; set; }
        public DbSet<reward_pack> reward_pack { get; set; }
        public DbSet<reward_pack_x_item> reward_pack_x_item { get; set; }
        public DbSet<ruleset_item_upgrade> ruleset_item_upgrade { get; set; }
        public DbSet<scaling_stat_distribution> scaling_stat_distribution { get; set; }
        public DbSet<scenario> scenarios { get; set; }
        public DbSet<scenario_locale> scenario_locale { get; set; }
        public DbSet<scenario_step> scenario_step { get; set; }
        public DbSet<scenario_step_locale> scenario_step_locale { get; set; }
        public DbSet<scene_script> scene_script { get; set; }
        public DbSet<scene_script_package> scene_script_package { get; set; }
        public DbSet<skill_line> skill_line { get; set; }
        public DbSet<skill_line_ability> skill_line_ability { get; set; }
        public DbSet<skill_line_locale> skill_line_locale { get; set; }
        public DbSet<skill_race_class_info> skill_race_class_info { get; set; }
        public DbSet<sound_kit> sound_kit { get; set; }
        public DbSet<sound_kit_locale> sound_kit_locale { get; set; }
        public DbSet<specialization_spells> specialization_spells { get; set; }
        public DbSet<specialization_spells_locale> specialization_spells_locale { get; set; }
        public DbSet<spell> spells { get; set; }
        public DbSet<spell_aura_options> spell_aura_options { get; set; }
        public DbSet<spell_aura_restrictions> spell_aura_restrictions { get; set; }
        public DbSet<spell_cast_times> spell_cast_times { get; set; }
        public DbSet<spell_casting_requirements> spell_casting_requirements { get; set; }
        public DbSet<spell_categories> spell_categories { get; set; }
        public DbSet<spell_category> spell_category { get; set; }
        public DbSet<spell_category_locale> spell_category_locale { get; set; }
        public DbSet<spell_class_options> spell_class_options { get; set; }
        public DbSet<spell_cooldowns> spell_cooldowns { get; set; }
        public DbSet<spell_duration> spell_duration { get; set; }
        public DbSet<spell_effect> spell_effect { get; set; }
        public DbSet<spell_effect_scaling> spell_effect_scaling { get; set; }
        public DbSet<spell_equipped_items> spell_equipped_items { get; set; }
        public DbSet<spell_focus_object> spell_focus_object { get; set; }
        public DbSet<spell_focus_object_locale> spell_focus_object_locale { get; set; }
        public DbSet<spell_interrupts> spell_interrupts { get; set; }
        public DbSet<spell_item_enchantment> spell_item_enchantment { get; set; }
        public DbSet<spell_item_enchantment_condition> spell_item_enchantment_condition { get; set; }
        public DbSet<spell_item_enchantment_locale> spell_item_enchantment_locale { get; set; }
        public DbSet<spell_learn_spell> spell_learn_spell { get; set; }
        public DbSet<spell_levels> spell_levels { get; set; }
        public DbSet<spell_locale> spell_locale { get; set; }
        public DbSet<spell_misc> spell_misc { get; set; }
        public DbSet<spell_power> spell_power { get; set; }
        public DbSet<spell_power_difficulty> spell_power_difficulty { get; set; }
        public DbSet<spell_procs_per_minute> spell_procs_per_minute { get; set; }
        public DbSet<spell_procs_per_minute_mod> spell_procs_per_minute_mod { get; set; }
        public DbSet<spell_radius> spell_radius { get; set; }
        public DbSet<spell_range> spell_range { get; set; }
        public DbSet<spell_range_locale> spell_range_locale { get; set; }
        public DbSet<spell_reagents> spell_reagents { get; set; }
        public DbSet<spell_scaling> spell_scaling { get; set; }
        public DbSet<spell_shapeshift> spell_shapeshift { get; set; }
        public DbSet<spell_shapeshift_form> spell_shapeshift_form { get; set; }
        public DbSet<spell_shapeshift_form_locale> spell_shapeshift_form_locale { get; set; }
        public DbSet<spell_target_restrictions> spell_target_restrictions { get; set; }
        public DbSet<spell_totems> spell_totems { get; set; }
        public DbSet<spell_x_spell_visual> spell_x_spell_visual { get; set; }
        public DbSet<summon_properties> summon_properties { get; set; }
        public DbSet<tact_key> tact_key { get; set; }
        public DbSet<talent> talents { get; set; }
        public DbSet<talent_locale> talent_locale { get; set; }
        public DbSet<taxi_nodes> taxi_nodes { get; set; }
        public DbSet<taxi_nodes_locale> taxi_nodes_locale { get; set; }
        public DbSet<taxi_path> taxi_path { get; set; }
        public DbSet<taxi_path_node> taxi_path_node { get; set; }
        public DbSet<totem_category> totem_category { get; set; }
        public DbSet<totem_category_locale> totem_category_locale { get; set; }
        public DbSet<toy> toys { get; set; }
        public DbSet<toy_locale> toy_locale { get; set; }
        public DbSet<transmog_holiday> transmog_holiday { get; set; }
        public DbSet<transmog_set> transmog_set { get; set; }
        public DbSet<transmog_set_group> transmog_set_group { get; set; }
        public DbSet<transmog_set_group_locale> transmog_set_group_locale { get; set; }
        public DbSet<transmog_set_item> transmog_set_item { get; set; }
        public DbSet<transmog_set_locale> transmog_set_locale { get; set; }
        public DbSet<transport_animation> transport_animation { get; set; }
        public DbSet<transport_rotation> transport_rotation { get; set; }
        public DbSet<unit_power_bar> unit_power_bar { get; set; }
        public DbSet<unit_power_bar_locale> unit_power_bar_locale { get; set; }
        public DbSet<update> updates { get; set; }
        public DbSet<updates_include> updates_include { get; set; }
        public DbSet<vehicle> vehicles { get; set; }
        public DbSet<vehicle_seat> vehicle_seat { get; set; }
        public DbSet<wmo_area_table> wmo_area_table { get; set; }
        public DbSet<wmo_area_table_locale> wmo_area_table_locale { get; set; }
        public DbSet<world_effect> world_effect { get; set; }
        public DbSet<world_map_area> world_map_area { get; set; }
        public DbSet<world_map_overlay> world_map_overlay { get; set; }
        public DbSet<world_map_transforms> world_map_transforms { get; set; }
        public DbSet<world_safe_locs> world_safe_locs { get; set; }
        public DbSet<world_safe_locs_locale> world_safe_locs_locale { get; set; }
    }
}
