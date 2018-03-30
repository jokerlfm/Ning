using MingCore;
using NingCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Business
{
    public class RealmReceiveBufferHandler
    {
        private RealmReceiveBufferHandler()
        {
            #region Init handler dic
            handlerDic = new Dictionary<REALM_OPCODE, RealmOpcodeHandlingDelegate>();
            handlerDic.Add(REALM_OPCODE.NONE, new RealmOpcodeHandlingDelegate(HandleNONE));
            handlerDic.Add(REALM_OPCODE.CMSG_ACCEPT_GUILD_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_ACCEPT_GUILD_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_ACCEPT_LEVEL_GRANT, new RealmOpcodeHandlingDelegate(HandleCMSG_ACCEPT_LEVEL_GRANT));
            handlerDic.Add(REALM_OPCODE.CMSG_ACCEPT_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_ACCEPT_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_ACCEPT_WARGAME_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_ACCEPT_WARGAME_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_ACTIVATE_TAXI, new RealmOpcodeHandlingDelegate(HandleCMSG_ACTIVATE_TAXI));
            handlerDic.Add(REALM_OPCODE.CMSG_ADDON_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_ADDON_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_ADD_BATTLENET_FRIEND, new RealmOpcodeHandlingDelegate(HandleCMSG_ADD_BATTLENET_FRIEND));
            handlerDic.Add(REALM_OPCODE.CMSG_ADD_FRIEND, new RealmOpcodeHandlingDelegate(HandleCMSG_ADD_FRIEND));
            handlerDic.Add(REALM_OPCODE.CMSG_ADD_IGNORE, new RealmOpcodeHandlingDelegate(HandleCMSG_ADD_IGNORE));
            handlerDic.Add(REALM_OPCODE.CMSG_ADD_TOY, new RealmOpcodeHandlingDelegate(HandleCMSG_ADD_TOY));
            handlerDic.Add(REALM_OPCODE.CMSG_ADVENTURE_JOURNAL_OPEN_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_ADVENTURE_JOURNAL_OPEN_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_ADVENTURE_JOURNAL_START_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_ADVENTURE_JOURNAL_START_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_ALTER_APPEARANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_ALTER_APPEARANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_AREA_SPIRIT_HEALER_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_AREA_SPIRIT_HEALER_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_AREA_SPIRIT_HEALER_QUEUE, new RealmOpcodeHandlingDelegate(HandleCMSG_AREA_SPIRIT_HEALER_QUEUE));
            handlerDic.Add(REALM_OPCODE.CMSG_AREA_TRIGGER, new RealmOpcodeHandlingDelegate(HandleCMSG_AREA_TRIGGER));
            handlerDic.Add(REALM_OPCODE.CMSG_ARTIFACT_ADD_POWER, new RealmOpcodeHandlingDelegate(HandleCMSG_ARTIFACT_ADD_POWER));
            handlerDic.Add(REALM_OPCODE.CMSG_ARTIFACT_SET_APPEARANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_ARTIFACT_SET_APPEARANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_ASSIGN_EQUIPMENT_SET_SPEC, new RealmOpcodeHandlingDelegate(HandleCMSG_ASSIGN_EQUIPMENT_SET_SPEC));
            handlerDic.Add(REALM_OPCODE.CMSG_ATTACK_STOP, new RealmOpcodeHandlingDelegate(HandleCMSG_ATTACK_STOP));
            handlerDic.Add(REALM_OPCODE.CMSG_ATTACK_SWING, new RealmOpcodeHandlingDelegate(HandleCMSG_ATTACK_SWING));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_HELLO_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_HELLO_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_LIST_BIDDER_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_LIST_BIDDER_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_LIST_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_LIST_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_LIST_OWNER_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_LIST_OWNER_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_LIST_PENDING_SALES, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_LIST_PENDING_SALES));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_PLACE_BID, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_PLACE_BID));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_REMOVE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_REMOVE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_REPLICATE_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_REPLICATE_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_AUCTION_SELL_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUCTION_SELL_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTH_CONTINUED_SESSION, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTH_CONTINUED_SESSION));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTH_SESSION, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTH_SESSION));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTOBANK_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTOBANK_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTOBANK_REAGENT, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTOBANK_REAGENT));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTOSTORE_BANK_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTOSTORE_BANK_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTOSTORE_BANK_REAGENT, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTOSTORE_BANK_REAGENT));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTO_EQUIP_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTO_EQUIP_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTO_EQUIP_ITEM_SLOT, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTO_EQUIP_ITEM_SLOT));
            handlerDic.Add(REALM_OPCODE.CMSG_AUTO_STORE_BAG_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_AUTO_STORE_BAG_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_BANKER_ACTIVATE, new RealmOpcodeHandlingDelegate(HandleCMSG_BANKER_ACTIVATE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEFIELD_LEAVE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEFIELD_LEAVE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEFIELD_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEFIELD_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEFIELD_PORT, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEFIELD_PORT));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEMASTER_HELLO, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEMASTER_HELLO));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEMASTER_JOIN, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEMASTER_JOIN));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEMASTER_JOIN_ARENA, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEMASTER_JOIN_ARENA));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEMASTER_JOIN_BRAWL, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEMASTER_JOIN_BRAWL));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLEMASTER_JOIN_SKIRMISH, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLEMASTER_JOIN_SKIRMISH));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLENET_CHALLENGE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLENET_CHALLENGE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLENET_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLENET_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLENET_REQUEST_REALM_LIST_TICKET, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLENET_REQUEST_REALM_LIST_TICKET));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_ACK_FAILED_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_ACK_FAILED_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_CONFIRM_PURCHASE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_CONFIRM_PURCHASE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_DISTRIBUTION_ASSIGN_TO_TARGET, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_DISTRIBUTION_ASSIGN_TO_TARGET));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_GET_PRODUCT_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_GET_PRODUCT_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_GET_PURCHASE_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_GET_PURCHASE_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_QUERY_CLASS_TRIAL_BOOST_RESULT, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_QUERY_CLASS_TRIAL_BOOST_RESULT));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_REQUEST_CHARACTER_BOOST_UNREVOKE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_REQUEST_CHARACTER_BOOST_UNREVOKE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_REQUEST_CURRENT_VAS_TRANSFER_QUEUES, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_REQUEST_CURRENT_VAS_TRANSFER_QUEUES));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_REQUEST_PRICE_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_REQUEST_PRICE_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_REQUEST_VAS_CHARACTER_QUEUE_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_REQUEST_VAS_CHARACTER_QUEUE_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_START_PURCHASE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_START_PURCHASE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_START_VAS_PURCHASE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_START_VAS_PURCHASE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_TRIAL_BOOST_CHARACTER, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_TRIAL_BOOST_CHARACTER));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PAY_VALIDATE_BNET_VAS_TRANSFER, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PAY_VALIDATE_BNET_VAS_TRANSFER));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_CLEAR_FANFARE, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_CLEAR_FANFARE));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_DELETE_PET, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_DELETE_PET));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_DELETE_PET_CHEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_DELETE_PET_CHEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_MODIFY_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_MODIFY_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_REQUEST_JOURNAL, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_REQUEST_JOURNAL));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_REQUEST_JOURNAL_LOCK, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_REQUEST_JOURNAL_LOCK));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_SET_BATTLE_SLOT, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_SET_BATTLE_SLOT));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_SET_FLAGS, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_SET_FLAGS));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_SUMMON, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_SUMMON));
            handlerDic.Add(REALM_OPCODE.CMSG_BATTLE_PET_UPDATE_NOTIFY, new RealmOpcodeHandlingDelegate(HandleCMSG_BATTLE_PET_UPDATE_NOTIFY));
            handlerDic.Add(REALM_OPCODE.CMSG_BEGIN_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_BEGIN_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_BINDER_ACTIVATE, new RealmOpcodeHandlingDelegate(HandleCMSG_BINDER_ACTIVATE));
            handlerDic.Add(REALM_OPCODE.CMSG_BLACK_MARKET_BID_ON_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_BLACK_MARKET_BID_ON_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_BLACK_MARKET_OPEN, new RealmOpcodeHandlingDelegate(HandleCMSG_BLACK_MARKET_OPEN));
            handlerDic.Add(REALM_OPCODE.CMSG_BLACK_MARKET_REQUEST_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_BLACK_MARKET_REQUEST_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_BUG_REPORT, new RealmOpcodeHandlingDelegate(HandleCMSG_BUG_REPORT));
            handlerDic.Add(REALM_OPCODE.CMSG_BUSY_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_BUSY_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_BACK_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_BACK_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_BANK_SLOT, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_BANK_SLOT));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_REAGENT_BANK, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_REAGENT_BANK));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_WOW_TOKEN_CONFIRM, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_WOW_TOKEN_CONFIRM));
            handlerDic.Add(REALM_OPCODE.CMSG_BUY_WOW_TOKEN_START, new RealmOpcodeHandlingDelegate(HandleCMSG_BUY_WOW_TOKEN_START));
            handlerDic.Add(REALM_OPCODE.CMSG_CAGE_BATTLE_PET, new RealmOpcodeHandlingDelegate(HandleCMSG_CAGE_BATTLE_PET));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_ADD_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_ADD_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_COMPLAIN, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_COMPLAIN));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_COPY_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_COPY_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_EVENT_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_EVENT_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_EVENT_MODERATOR_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_EVENT_MODERATOR_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_EVENT_RSVP, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_EVENT_RSVP));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_EVENT_SIGN_UP, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_EVENT_SIGN_UP));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_EVENT_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_EVENT_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_GET, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_GET));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_GET_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_GET_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_GET_NUM_PENDING, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_GET_NUM_PENDING));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_GUILD_FILTER, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_GUILD_FILTER));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_REMOVE_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_REMOVE_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_REMOVE_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_REMOVE_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_CALENDAR_UPDATE_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CALENDAR_UPDATE_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_AURA, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_AURA));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_AUTO_REPEAT_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_AUTO_REPEAT_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_CAST, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_CAST));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_CHANNELLING, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_CHANNELLING));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_GROWTH_AURA, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_GROWTH_AURA));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_MASTER_LOOT_ROLL, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_MASTER_LOOT_ROLL));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_MOD_SPEED_NO_CONTROL_AURAS, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_MOD_SPEED_NO_CONTROL_AURAS));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_MOUNT_AURA, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_MOUNT_AURA));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_QUEUED_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_QUEUED_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_TEMP_ENCHANTMENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_TEMP_ENCHANTMENT));
            handlerDic.Add(REALM_OPCODE.CMSG_CANCEL_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_CANCEL_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_CAN_DUEL, new RealmOpcodeHandlingDelegate(HandleCMSG_CAN_DUEL));
            handlerDic.Add(REALM_OPCODE.CMSG_CAN_REDEEM_WOW_TOKEN_FOR_BALANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_CAN_REDEEM_WOW_TOKEN_FOR_BALANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_CAST_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_CAST_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHALLENGE_MODE_REQUEST_LEADERS, new RealmOpcodeHandlingDelegate(HandleCMSG_CHALLENGE_MODE_REQUEST_LEADERS));
            handlerDic.Add(REALM_OPCODE.CMSG_CHALLENGE_MODE_REQUEST_MAP_STATS, new RealmOpcodeHandlingDelegate(HandleCMSG_CHALLENGE_MODE_REQUEST_MAP_STATS));
            handlerDic.Add(REALM_OPCODE.CMSG_CHANGE_BAG_SLOT_FLAG, new RealmOpcodeHandlingDelegate(HandleCMSG_CHANGE_BAG_SLOT_FLAG));
            handlerDic.Add(REALM_OPCODE.CMSG_CHANGE_MONUMENT_APPEARANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHANGE_MONUMENT_APPEARANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHANGE_SUB_GROUP, new RealmOpcodeHandlingDelegate(HandleCMSG_CHANGE_SUB_GROUP));
            handlerDic.Add(REALM_OPCODE.CMSG_CHARACTER_RENAME_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_CHARACTER_RENAME_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAR_CUSTOMIZE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAR_CUSTOMIZE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAR_DELETE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAR_DELETE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAR_RACE_OR_FACTION_CHANGE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAR_RACE_OR_FACTION_CHANGE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_CHANNEL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_CHANNEL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_GUILD, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_GUILD));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_INSTANCE_CHAT, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_INSTANCE_CHAT));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_OFFICER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_OFFICER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_PARTY, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_PARTY));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_RAID, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_RAID));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_ADDON_MESSAGE_WHISPER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_ADDON_MESSAGE_WHISPER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_ANNOUNCEMENTS, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_ANNOUNCEMENTS));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_BAN, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_BAN));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_DECLINE_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_DECLINE_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_DISPLAY_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_DISPLAY_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_KICK, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_KICK));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_MODERATE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_MODERATE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_MODERATOR, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_MODERATOR));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_MUTE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_MUTE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_OWNER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_OWNER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_PASSWORD, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_PASSWORD));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_SET_OWNER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_SET_OWNER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_SILENCE_ALL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_SILENCE_ALL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_UNBAN, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_UNBAN));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_UNMODERATOR, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_UNMODERATOR));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_UNMUTE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_UNMUTE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_CHANNEL_UNSILENCE_ALL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_CHANNEL_UNSILENCE_ALL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_JOIN_CHANNEL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_JOIN_CHANNEL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_LEAVE_CHANNEL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_LEAVE_CHANNEL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_AFK, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_AFK));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_CHANNEL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_CHANNEL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_DND, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_DND));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_EMOTE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_EMOTE));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_GUILD, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_GUILD));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_INSTANCE_CHAT, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_INSTANCE_CHAT));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_OFFICER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_OFFICER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_PARTY, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_PARTY));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_RAID, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_RAID));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_RAID_WARNING, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_RAID_WARNING));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_SAY, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_SAY));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_WHISPER, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_WHISPER));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_MESSAGE_YELL, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_MESSAGE_YELL));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_REGISTER_ADDON_PREFIXES, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_REGISTER_ADDON_PREFIXES));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_REPORT_FILTERED, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_REPORT_FILTERED));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_REPORT_IGNORED, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_REPORT_IGNORED));
            handlerDic.Add(REALM_OPCODE.CMSG_CHAT_UNREGISTER_ALL_ADDON_PREFIXES, new RealmOpcodeHandlingDelegate(HandleCMSG_CHAT_UNREGISTER_ALL_ADDON_PREFIXES));
            handlerDic.Add(REALM_OPCODE.CMSG_CHECK_RAF_EMAIL_ENABLED, new RealmOpcodeHandlingDelegate(HandleCMSG_CHECK_RAF_EMAIL_ENABLED));
            handlerDic.Add(REALM_OPCODE.CMSG_CHECK_WOW_TOKEN_VETERAN_ELIGIBILITY, new RealmOpcodeHandlingDelegate(HandleCMSG_CHECK_WOW_TOKEN_VETERAN_ELIGIBILITY));
            handlerDic.Add(REALM_OPCODE.CMSG_CHOICE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_CHOICE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_CLEAR_RAID_MARKER, new RealmOpcodeHandlingDelegate(HandleCMSG_CLEAR_RAID_MARKER));
            handlerDic.Add(REALM_OPCODE.CMSG_CLEAR_TRADE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_CLEAR_TRADE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_CLIENT_PORT_GRAVEYARD, new RealmOpcodeHandlingDelegate(HandleCMSG_CLIENT_PORT_GRAVEYARD));
            handlerDic.Add(REALM_OPCODE.CMSG_CLOSE_INTERACTION, new RealmOpcodeHandlingDelegate(HandleCMSG_CLOSE_INTERACTION));
            handlerDic.Add(REALM_OPCODE.CMSG_COLLECTION_ITEM_SET_FAVORITE, new RealmOpcodeHandlingDelegate(HandleCMSG_COLLECTION_ITEM_SET_FAVORITE));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_ENABLE, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_ENABLE));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_ENTER_INSTANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_ENTER_INSTANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_EXIT_INSTANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_EXIT_INSTANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_GET_MAP_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_GET_MAP_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_GET_PLAYER_COOLDOWNS, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_GET_PLAYER_COOLDOWNS));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_GET_PLAYER_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_GET_PLAYER_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_COMMENTATOR_START_WARGAME, new RealmOpcodeHandlingDelegate(HandleCMSG_COMMENTATOR_START_WARGAME));
            handlerDic.Add(REALM_OPCODE.CMSG_COMPLAINT, new RealmOpcodeHandlingDelegate(HandleCMSG_COMPLAINT));
            handlerDic.Add(REALM_OPCODE.CMSG_COMPLETE_CINEMATIC, new RealmOpcodeHandlingDelegate(HandleCMSG_COMPLETE_CINEMATIC));
            handlerDic.Add(REALM_OPCODE.CMSG_COMPLETE_MOVIE, new RealmOpcodeHandlingDelegate(HandleCMSG_COMPLETE_MOVIE));
            handlerDic.Add(REALM_OPCODE.CMSG_CONFIRM_ARTIFACT_RESPEC, new RealmOpcodeHandlingDelegate(HandleCMSG_CONFIRM_ARTIFACT_RESPEC));
            handlerDic.Add(REALM_OPCODE.CMSG_CONFIRM_RESPEC_WIPE, new RealmOpcodeHandlingDelegate(HandleCMSG_CONFIRM_RESPEC_WIPE));
            handlerDic.Add(REALM_OPCODE.CMSG_CONNECT_TO_FAILED, new RealmOpcodeHandlingDelegate(HandleCMSG_CONNECT_TO_FAILED));
            handlerDic.Add(REALM_OPCODE.CMSG_CONTRIBUTION_CONTRIBUTE, new RealmOpcodeHandlingDelegate(HandleCMSG_CONTRIBUTION_CONTRIBUTE));
            handlerDic.Add(REALM_OPCODE.CMSG_CONTRIBUTION_GET_STATE, new RealmOpcodeHandlingDelegate(HandleCMSG_CONTRIBUTION_GET_STATE));
            handlerDic.Add(REALM_OPCODE.CMSG_CONVERT_CONSUMPTION_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_CONVERT_CONSUMPTION_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_CONVERT_RAID, new RealmOpcodeHandlingDelegate(HandleCMSG_CONVERT_RAID));
            handlerDic.Add(REALM_OPCODE.CMSG_CREATE_CHARACTER, new RealmOpcodeHandlingDelegate(HandleCMSG_CREATE_CHARACTER));
            handlerDic.Add(REALM_OPCODE.CMSG_CREATE_SHIPMENT, new RealmOpcodeHandlingDelegate(HandleCMSG_CREATE_SHIPMENT));
            handlerDic.Add(REALM_OPCODE.CMSG_DB_QUERY_BULK, new RealmOpcodeHandlingDelegate(HandleCMSG_DB_QUERY_BULK));
            handlerDic.Add(REALM_OPCODE.CMSG_DECLINE_GUILD_INVITES, new RealmOpcodeHandlingDelegate(HandleCMSG_DECLINE_GUILD_INVITES));
            handlerDic.Add(REALM_OPCODE.CMSG_DECLINE_PETITION, new RealmOpcodeHandlingDelegate(HandleCMSG_DECLINE_PETITION));
            handlerDic.Add(REALM_OPCODE.CMSG_DELETE_EQUIPMENT_SET, new RealmOpcodeHandlingDelegate(HandleCMSG_DELETE_EQUIPMENT_SET));
            handlerDic.Add(REALM_OPCODE.CMSG_DEL_FRIEND, new RealmOpcodeHandlingDelegate(HandleCMSG_DEL_FRIEND));
            handlerDic.Add(REALM_OPCODE.CMSG_DEL_IGNORE, new RealmOpcodeHandlingDelegate(HandleCMSG_DEL_IGNORE));
            handlerDic.Add(REALM_OPCODE.CMSG_DEPOSIT_REAGENT_BANK, new RealmOpcodeHandlingDelegate(HandleCMSG_DEPOSIT_REAGENT_BANK));
            handlerDic.Add(REALM_OPCODE.CMSG_DESTROY_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_DESTROY_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_BOOT_PLAYER_VOTE, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_BOOT_PLAYER_VOTE));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_GET_JOIN_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_GET_JOIN_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_GET_SYSTEM_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_GET_SYSTEM_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_JOIN, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_JOIN));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_LEAVE, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_LEAVE));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_PROPOSAL_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_PROPOSAL_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_READY_CHECK_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_READY_CHECK_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_SET_ROLES, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_SET_ROLES));
            handlerDic.Add(REALM_OPCODE.CMSG_DF_TELEPORT, new RealmOpcodeHandlingDelegate(HandleCMSG_DF_TELEPORT));
            handlerDic.Add(REALM_OPCODE.CMSG_DISCARDED_TIME_SYNC_ACKS, new RealmOpcodeHandlingDelegate(HandleCMSG_DISCARDED_TIME_SYNC_ACKS));
            handlerDic.Add(REALM_OPCODE.CMSG_DISMISS_CRITTER, new RealmOpcodeHandlingDelegate(HandleCMSG_DISMISS_CRITTER));
            handlerDic.Add(REALM_OPCODE.CMSG_DO_MASTER_LOOT_ROLL, new RealmOpcodeHandlingDelegate(HandleCMSG_DO_MASTER_LOOT_ROLL));
            handlerDic.Add(REALM_OPCODE.CMSG_DO_READY_CHECK, new RealmOpcodeHandlingDelegate(HandleCMSG_DO_READY_CHECK));
            handlerDic.Add(REALM_OPCODE.CMSG_DUEL_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_DUEL_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_EJECT_PASSENGER, new RealmOpcodeHandlingDelegate(HandleCMSG_EJECT_PASSENGER));
            handlerDic.Add(REALM_OPCODE.CMSG_EMOTE, new RealmOpcodeHandlingDelegate(HandleCMSG_EMOTE));
            handlerDic.Add(REALM_OPCODE.CMSG_ENABLE_ENCRYPTION_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_ENABLE_ENCRYPTION_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_ENABLE_NAGLE, new RealmOpcodeHandlingDelegate(HandleCMSG_ENABLE_NAGLE));
            handlerDic.Add(REALM_OPCODE.CMSG_ENABLE_TAXI_NODE, new RealmOpcodeHandlingDelegate(HandleCMSG_ENABLE_TAXI_NODE));
            handlerDic.Add(REALM_OPCODE.CMSG_ENGINE_SURVEY, new RealmOpcodeHandlingDelegate(HandleCMSG_ENGINE_SURVEY));
            handlerDic.Add(REALM_OPCODE.CMSG_ENUM_CHARACTERS, new RealmOpcodeHandlingDelegate(HandleCMSG_ENUM_CHARACTERS));
            handlerDic.Add(REALM_OPCODE.CMSG_ENUM_CHARACTERS_DELETED_BY_CLIENT, new RealmOpcodeHandlingDelegate(HandleCMSG_ENUM_CHARACTERS_DELETED_BY_CLIENT));
            handlerDic.Add(REALM_OPCODE.CMSG_FAR_SIGHT, new RealmOpcodeHandlingDelegate(HandleCMSG_FAR_SIGHT));
            handlerDic.Add(REALM_OPCODE.CMSG_GAME_OBJ_REPORT_USE, new RealmOpcodeHandlingDelegate(HandleCMSG_GAME_OBJ_REPORT_USE));
            handlerDic.Add(REALM_OPCODE.CMSG_GAME_OBJ_USE, new RealmOpcodeHandlingDelegate(HandleCMSG_GAME_OBJ_USE));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_ASSIGN_FOLLOWER_TO_BUILDING, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_ASSIGN_FOLLOWER_TO_BUILDING));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_CANCEL_CONSTRUCTION, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_CANCEL_CONSTRUCTION));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_CHECK_UPGRADEABLE, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_CHECK_UPGRADEABLE));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_COMPLETE_MISSION, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_COMPLETE_MISSION));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_GENERATE_RECRUITS, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_GENERATE_RECRUITS));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_GET_BUILDING_LANDMARKS, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_GET_BUILDING_LANDMARKS));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_GET_MISSION_REWARD, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_GET_MISSION_REWARD));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_MISSION_BONUS_ROLL, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_MISSION_BONUS_ROLL));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_PURCHASE_BUILDING, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_PURCHASE_BUILDING));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_RECRUIT_FOLLOWER, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_RECRUIT_FOLLOWER));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REMOVE_FOLLOWER, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REMOVE_FOLLOWER));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REMOVE_FOLLOWER_FROM_BUILDING, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REMOVE_FOLLOWER_FROM_BUILDING));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_RENAME_FOLLOWER, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_RENAME_FOLLOWER));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REQUEST_BLUEPRINT_AND_SPECIALIZATION_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REQUEST_BLUEPRINT_AND_SPECIALIZATION_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REQUEST_CLASS_SPEC_CATEGORY_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REQUEST_CLASS_SPEC_CATEGORY_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REQUEST_LANDING_PAGE_SHIPMENT_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REQUEST_LANDING_PAGE_SHIPMENT_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_REQUEST_SHIPMENT_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_REQUEST_SHIPMENT_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_RESEARCH_TALENT, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_RESEARCH_TALENT));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_SET_BUILDING_ACTIVE, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_SET_BUILDING_ACTIVE));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_SET_FOLLOWER_FAVORITE, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_SET_FOLLOWER_FAVORITE));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_SET_FOLLOWER_INACTIVE, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_SET_FOLLOWER_INACTIVE));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_SET_RECRUITMENT_PREFERENCES, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_SET_RECRUITMENT_PREFERENCES));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_START_MISSION, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_START_MISSION));
            handlerDic.Add(REALM_OPCODE.CMSG_GARRISON_SWAP_BUILDINGS, new RealmOpcodeHandlingDelegate(HandleCMSG_GARRISON_SWAP_BUILDINGS));
            handlerDic.Add(REALM_OPCODE.CMSG_GENERATE_RANDOM_CHARACTER_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_GENERATE_RANDOM_CHARACTER_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_CHALLENGE_MODE_REWARDS, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_CHALLENGE_MODE_REWARDS));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_GARRISON_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_GARRISON_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_ITEM_PURCHASE_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_ITEM_PURCHASE_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_MIRROR_IMAGE_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_MIRROR_IMAGE_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_PVP_OPTIONS_ENABLED, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_PVP_OPTIONS_ENABLED));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_REMAINING_GAME_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_REMAINING_GAME_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_TROPHY_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_TROPHY_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_GET_UNDELETE_CHARACTER_COOLDOWN_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_GET_UNDELETE_CHARACTER_COOLDOWN_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_GM_TICKET_ACKNOWLEDGE_SURVEY, new RealmOpcodeHandlingDelegate(HandleCMSG_GM_TICKET_ACKNOWLEDGE_SURVEY));
            handlerDic.Add(REALM_OPCODE.CMSG_GM_TICKET_GET_CASE_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_GM_TICKET_GET_CASE_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_GM_TICKET_GET_SYSTEM_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_GM_TICKET_GET_SYSTEM_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_GOSSIP_SELECT_OPTION, new RealmOpcodeHandlingDelegate(HandleCMSG_GOSSIP_SELECT_OPTION));
            handlerDic.Add(REALM_OPCODE.CMSG_GRANT_LEVEL, new RealmOpcodeHandlingDelegate(HandleCMSG_GRANT_LEVEL));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_ADD_BATTLENET_FRIEND, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_ADD_BATTLENET_FRIEND));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_ADD_RANK, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_ADD_RANK));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_ASSIGN_MEMBER_RANK, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_ASSIGN_MEMBER_RANK));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_AUTO_DECLINE_INVITATION, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_AUTO_DECLINE_INVITATION));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_ACTIVATE, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_ACTIVATE));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_BUY_TAB, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_BUY_TAB));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_DEPOSIT_MONEY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_DEPOSIT_MONEY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_LOG_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_LOG_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_QUERY_TAB, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_QUERY_TAB));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_SET_TAB_TEXT, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_SET_TAB_TEXT));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_SWAP_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_SWAP_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_TEXT_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_TEXT_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_UPDATE_TAB, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_UPDATE_TAB));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_BANK_WITHDRAW_MONEY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_BANK_WITHDRAW_MONEY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_CHALLENGE_UPDATE_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_CHALLENGE_UPDATE_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_CHANGE_NAME_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_CHANGE_NAME_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_DECLINE_INVITATION, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_DECLINE_INVITATION));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_DELETE, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_DELETE));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_DELETE_RANK, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_DELETE_RANK));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_DEMOTE_MEMBER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_DEMOTE_MEMBER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_EVENT_LOG_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_EVENT_LOG_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_GET_ACHIEVEMENT_MEMBERS, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_GET_ACHIEVEMENT_MEMBERS));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_GET_RANKS, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_GET_RANKS));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_GET_ROSTER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_GET_ROSTER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_INVITE_BY_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_INVITE_BY_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_LEAVE, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_LEAVE));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_MEMBER_SEND_SOR_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_MEMBER_SEND_SOR_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_NEWS_UPDATE_STICKY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_NEWS_UPDATE_STICKY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_OFFICER_REMOVE_MEMBER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_OFFICER_REMOVE_MEMBER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_PERMISSIONS_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_PERMISSIONS_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_PROMOTE_MEMBER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_PROMOTE_MEMBER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_QUERY_MEMBERS_FOR_RECIPE, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_QUERY_MEMBERS_FOR_RECIPE));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_QUERY_MEMBER_RECIPES, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_QUERY_MEMBER_RECIPES));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_QUERY_NEWS, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_QUERY_NEWS));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_QUERY_RECIPES, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_QUERY_RECIPES));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_REPLACE_GUILD_MASTER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_REPLACE_GUILD_MASTER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SET_ACHIEVEMENT_TRACKING, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SET_ACHIEVEMENT_TRACKING));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SET_FOCUSED_ACHIEVEMENT, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SET_FOCUSED_ACHIEVEMENT));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SET_GUILD_MASTER, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SET_GUILD_MASTER));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SET_MEMBER_NOTE, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SET_MEMBER_NOTE));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SET_RANK_PERMISSIONS, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SET_RANK_PERMISSIONS));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_SHIFT_RANK, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_SHIFT_RANK));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_UPDATE_INFO_TEXT, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_UPDATE_INFO_TEXT));
            handlerDic.Add(REALM_OPCODE.CMSG_GUILD_UPDATE_MOTD_TEXT, new RealmOpcodeHandlingDelegate(HandleCMSG_GUILD_UPDATE_MOTD_TEXT));
            handlerDic.Add(REALM_OPCODE.CMSG_HEARTH_AND_RESURRECT, new RealmOpcodeHandlingDelegate(HandleCMSG_HEARTH_AND_RESURRECT));
            handlerDic.Add(REALM_OPCODE.CMSG_HOTFIX_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_HOTFIX_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_IGNORE_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_IGNORE_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_INITIATE_ROLE_POLL, new RealmOpcodeHandlingDelegate(HandleCMSG_INITIATE_ROLE_POLL));
            handlerDic.Add(REALM_OPCODE.CMSG_INITIATE_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_INITIATE_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_INSPECT, new RealmOpcodeHandlingDelegate(HandleCMSG_INSPECT));
            handlerDic.Add(REALM_OPCODE.CMSG_INSPECT_PVP, new RealmOpcodeHandlingDelegate(HandleCMSG_INSPECT_PVP));
            handlerDic.Add(REALM_OPCODE.CMSG_INSTANCE_LOCK_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_INSTANCE_LOCK_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_ITEM_PURCHASE_REFUND, new RealmOpcodeHandlingDelegate(HandleCMSG_ITEM_PURCHASE_REFUND));
            handlerDic.Add(REALM_OPCODE.CMSG_ITEM_TEXT_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_ITEM_TEXT_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_JOIN_PET_BATTLE_QUEUE, new RealmOpcodeHandlingDelegate(HandleCMSG_JOIN_PET_BATTLE_QUEUE));
            handlerDic.Add(REALM_OPCODE.CMSG_JOIN_RATED_BATTLEGROUND, new RealmOpcodeHandlingDelegate(HandleCMSG_JOIN_RATED_BATTLEGROUND));
            handlerDic.Add(REALM_OPCODE.CMSG_KEEP_ALIVE, new RealmOpcodeHandlingDelegate(HandleCMSG_KEEP_ALIVE));
            handlerDic.Add(REALM_OPCODE.CMSG_KEYBOUND_OVERRIDE, new RealmOpcodeHandlingDelegate(HandleCMSG_KEYBOUND_OVERRIDE));
            handlerDic.Add(REALM_OPCODE.CMSG_LEARN_PVP_TALENTS, new RealmOpcodeHandlingDelegate(HandleCMSG_LEARN_PVP_TALENTS));
            handlerDic.Add(REALM_OPCODE.CMSG_LEARN_TALENTS, new RealmOpcodeHandlingDelegate(HandleCMSG_LEARN_TALENTS));
            handlerDic.Add(REALM_OPCODE.CMSG_LEAVE_GROUP, new RealmOpcodeHandlingDelegate(HandleCMSG_LEAVE_GROUP));
            handlerDic.Add(REALM_OPCODE.CMSG_LEAVE_PET_BATTLE_QUEUE, new RealmOpcodeHandlingDelegate(HandleCMSG_LEAVE_PET_BATTLE_QUEUE));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_APPLY_TO_GROUP, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_APPLY_TO_GROUP));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_CANCEL_APPLICATION, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_CANCEL_APPLICATION));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_DECLINE_APPLICANT, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_DECLINE_APPLICANT));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_GET_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_GET_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_INVITE_APPLICANT, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_INVITE_APPLICANT));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_INVITE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_INVITE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_JOIN, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_JOIN));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_LEAVE, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_LEAVE));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_SEARCH, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_SEARCH));
            handlerDic.Add(REALM_OPCODE.CMSG_LFG_LIST_UPDATE_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_LFG_LIST_UPDATE_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_ADD_RECRUIT, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_ADD_RECRUIT));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_BROWSE, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_BROWSE));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_DECLINE_RECRUIT, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_DECLINE_RECRUIT));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_GET_APPLICATIONS, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_GET_APPLICATIONS));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_GET_GUILD_POST, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_GET_GUILD_POST));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_GET_RECRUITS, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_GET_RECRUITS));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_REMOVE_RECRUIT, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_REMOVE_RECRUIT));
            handlerDic.Add(REALM_OPCODE.CMSG_LF_GUILD_SET_GUILD_POST, new RealmOpcodeHandlingDelegate(HandleCMSG_LF_GUILD_SET_GUILD_POST));
            handlerDic.Add(REALM_OPCODE.CMSG_LIST_INVENTORY, new RealmOpcodeHandlingDelegate(HandleCMSG_LIST_INVENTORY));
            handlerDic.Add(REALM_OPCODE.CMSG_LIVE_REGION_ACCOUNT_RESTORE, new RealmOpcodeHandlingDelegate(HandleCMSG_LIVE_REGION_ACCOUNT_RESTORE));
            handlerDic.Add(REALM_OPCODE.CMSG_LIVE_REGION_CHARACTER_COPY, new RealmOpcodeHandlingDelegate(HandleCMSG_LIVE_REGION_CHARACTER_COPY));
            handlerDic.Add(REALM_OPCODE.CMSG_LIVE_REGION_GET_ACCOUNT_CHARACTER_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_LIVE_REGION_GET_ACCOUNT_CHARACTER_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_LOADING_SCREEN_NOTIFY, new RealmOpcodeHandlingDelegate(HandleCMSG_LOADING_SCREEN_NOTIFY));
            handlerDic.Add(REALM_OPCODE.CMSG_LOAD_SELECTED_TROPHY, new RealmOpcodeHandlingDelegate(HandleCMSG_LOAD_SELECTED_TROPHY));
            handlerDic.Add(REALM_OPCODE.CMSG_LOGOUT_CANCEL, new RealmOpcodeHandlingDelegate(HandleCMSG_LOGOUT_CANCEL));
            handlerDic.Add(REALM_OPCODE.CMSG_LOGOUT_INSTANT, new RealmOpcodeHandlingDelegate(HandleCMSG_LOGOUT_INSTANT));
            handlerDic.Add(REALM_OPCODE.CMSG_LOGOUT_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_LOGOUT_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_LOG_DISCONNECT, new RealmOpcodeHandlingDelegate(HandleCMSG_LOG_DISCONNECT));
            handlerDic.Add(REALM_OPCODE.CMSG_LOG_STREAMING_ERROR, new RealmOpcodeHandlingDelegate(HandleCMSG_LOG_STREAMING_ERROR));
            handlerDic.Add(REALM_OPCODE.CMSG_LOOT_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_LOOT_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_LOOT_MONEY, new RealmOpcodeHandlingDelegate(HandleCMSG_LOOT_MONEY));
            handlerDic.Add(REALM_OPCODE.CMSG_LOOT_RELEASE, new RealmOpcodeHandlingDelegate(HandleCMSG_LOOT_RELEASE));
            handlerDic.Add(REALM_OPCODE.CMSG_LOOT_ROLL, new RealmOpcodeHandlingDelegate(HandleCMSG_LOOT_ROLL));
            handlerDic.Add(REALM_OPCODE.CMSG_LOOT_UNIT, new RealmOpcodeHandlingDelegate(HandleCMSG_LOOT_UNIT));
            handlerDic.Add(REALM_OPCODE.CMSG_LOW_LEVEL_RAID1, new RealmOpcodeHandlingDelegate(HandleCMSG_LOW_LEVEL_RAID1));
            handlerDic.Add(REALM_OPCODE.CMSG_LOW_LEVEL_RAID2, new RealmOpcodeHandlingDelegate(HandleCMSG_LOW_LEVEL_RAID2));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_CREATE_TEXT_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_CREATE_TEXT_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_DELETE, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_DELETE));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_GET_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_GET_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_MARK_AS_READ, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_MARK_AS_READ));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_RETURN_TO_SENDER, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_RETURN_TO_SENDER));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_TAKE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_TAKE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_MAIL_TAKE_MONEY, new RealmOpcodeHandlingDelegate(HandleCMSG_MAIL_TAKE_MONEY));
            handlerDic.Add(REALM_OPCODE.CMSG_MASTER_LOOT_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_MASTER_LOOT_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_MINIMAP_PING, new RealmOpcodeHandlingDelegate(HandleCMSG_MINIMAP_PING));
            handlerDic.Add(REALM_OPCODE.CMSG_MISSILE_TRAJECTORY_COLLISION, new RealmOpcodeHandlingDelegate(HandleCMSG_MISSILE_TRAJECTORY_COLLISION));
            handlerDic.Add(REALM_OPCODE.CMSG_MOUNT_CLEAR_FANFARE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOUNT_CLEAR_FANFARE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOUNT_SET_FAVORITE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOUNT_SET_FAVORITE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOUNT_SPECIAL_ANIM, new RealmOpcodeHandlingDelegate(HandleCMSG_MOUNT_SPECIAL_ANIM));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_APPLY_MOVEMENT_FORCE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_APPLY_MOVEMENT_FORCE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_CHANGE_TRANSPORT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_CHANGE_TRANSPORT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_CHANGE_VEHICLE_SEATS, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_CHANGE_VEHICLE_SEATS));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_DISMISS_VEHICLE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_DISMISS_VEHICLE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_DOUBLE_JUMP, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_DOUBLE_JUMP));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_ENABLE_DOUBLE_JUMP_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_ENABLE_DOUBLE_JUMP_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FALL_LAND, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FALL_LAND));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FALL_RESET, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FALL_RESET));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FEATHER_FALL_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FEATHER_FALL_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_PITCH_RATE_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_PITCH_RATE_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_ROOT_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_ROOT_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_SWIM_BACK_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_SWIM_BACK_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_TURN_RATE_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_TURN_RATE_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_UNROOT_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_UNROOT_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_GRAVITY_DISABLE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_GRAVITY_DISABLE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_GRAVITY_ENABLE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_GRAVITY_ENABLE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_HEARTBEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_HEARTBEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_HOVER_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_HOVER_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_JUMP, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_JUMP));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_KNOCK_BACK_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_KNOCK_BACK_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_REMOVE_MOVEMENT_FORCES, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_REMOVE_MOVEMENT_FORCES));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_REMOVE_MOVEMENT_FORCE_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_REMOVE_MOVEMENT_FORCE_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_CAN_FLY_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_CAN_FLY_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_CAN_TURN_WHILE_FALLING_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_CAN_TURN_WHILE_FALLING_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_COLLISION_HEIGHT_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_COLLISION_HEIGHT_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_FACING, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_FACING));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_FLY, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_FLY));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_IGNORE_MOVEMENT_FORCES_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_IGNORE_MOVEMENT_FORCES_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_PITCH, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_PITCH));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_RUN_MODE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_RUN_MODE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_VEHICLE_REC_ID_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_VEHICLE_REC_ID_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SET_WALK_MODE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SET_WALK_MODE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_SPLINE_DONE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_SPLINE_DONE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_ASCEND, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_ASCEND));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_BACKWARD, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_BACKWARD));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_DESCEND, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_DESCEND));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_FORWARD, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_FORWARD));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_PITCH_DOWN, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_PITCH_DOWN));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_PITCH_UP, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_PITCH_UP));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_STRAFE_LEFT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_STRAFE_LEFT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_STRAFE_RIGHT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_STRAFE_RIGHT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_SWIM, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_SWIM));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_TURN_LEFT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_TURN_LEFT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_START_TURN_RIGHT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_START_TURN_RIGHT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP_ASCEND, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP_ASCEND));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP_PITCH, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP_PITCH));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP_STRAFE, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP_STRAFE));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP_SWIM, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP_SWIM));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_STOP_TURN, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_STOP_TURN));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_TELEPORT_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_TELEPORT_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_TIME_SKIPPED, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_TIME_SKIPPED));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_TOGGLE_COLLISION_CHEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_TOGGLE_COLLISION_CHEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_MOVE_WATER_WALK_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_MOVE_WATER_WALK_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_NEUTRAL_PLAYER_SELECT_FACTION, new RealmOpcodeHandlingDelegate(HandleCMSG_NEUTRAL_PLAYER_SELECT_FACTION));
            handlerDic.Add(REALM_OPCODE.CMSG_NEXT_CINEMATIC_CAMERA, new RealmOpcodeHandlingDelegate(HandleCMSG_NEXT_CINEMATIC_CAMERA));
            handlerDic.Add(REALM_OPCODE.CMSG_OBJECT_UPDATE_FAILED, new RealmOpcodeHandlingDelegate(HandleCMSG_OBJECT_UPDATE_FAILED));
            handlerDic.Add(REALM_OPCODE.CMSG_OBJECT_UPDATE_RESCUED, new RealmOpcodeHandlingDelegate(HandleCMSG_OBJECT_UPDATE_RESCUED));
            handlerDic.Add(REALM_OPCODE.CMSG_OFFER_PETITION, new RealmOpcodeHandlingDelegate(HandleCMSG_OFFER_PETITION));
            handlerDic.Add(REALM_OPCODE.CMSG_OPENING_CINEMATIC, new RealmOpcodeHandlingDelegate(HandleCMSG_OPENING_CINEMATIC));
            handlerDic.Add(REALM_OPCODE.CMSG_OPEN_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_OPEN_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_OPEN_MISSION_NPC, new RealmOpcodeHandlingDelegate(HandleCMSG_OPEN_MISSION_NPC));
            handlerDic.Add(REALM_OPCODE.CMSG_OPEN_SHIPMENT_NPC, new RealmOpcodeHandlingDelegate(HandleCMSG_OPEN_SHIPMENT_NPC));
            handlerDic.Add(REALM_OPCODE.CMSG_OPEN_TRADESKILL_NPC, new RealmOpcodeHandlingDelegate(HandleCMSG_OPEN_TRADESKILL_NPC));
            handlerDic.Add(REALM_OPCODE.CMSG_OPT_OUT_OF_LOOT, new RealmOpcodeHandlingDelegate(HandleCMSG_OPT_OUT_OF_LOOT));
            handlerDic.Add(REALM_OPCODE.CMSG_PARTY_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_PARTY_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_PARTY_INVITE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_PARTY_INVITE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_PARTY_UNINVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_PARTY_UNINVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_PETITION_BUY, new RealmOpcodeHandlingDelegate(HandleCMSG_PETITION_BUY));
            handlerDic.Add(REALM_OPCODE.CMSG_PETITION_RENAME_GUILD, new RealmOpcodeHandlingDelegate(HandleCMSG_PETITION_RENAME_GUILD));
            handlerDic.Add(REALM_OPCODE.CMSG_PETITION_SHOW_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_PETITION_SHOW_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_PETITION_SHOW_SIGNATURES, new RealmOpcodeHandlingDelegate(HandleCMSG_PETITION_SHOW_SIGNATURES));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_ABANDON, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_ABANDON));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_ACTION, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_ACTION));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_FINAL_NOTIFY, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_FINAL_NOTIFY));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_INPUT, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_INPUT));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_QUEUE_PROPOSE_MATCH_RESULT, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_QUEUE_PROPOSE_MATCH_RESULT));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_QUIT_NOTIFY, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_QUIT_NOTIFY));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_REPLACE_FRONT_PET, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_REPLACE_FRONT_PET));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_REQUEST_PVP, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_REQUEST_PVP));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_REQUEST_UPDATE, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_REQUEST_UPDATE));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_REQUEST_WILD, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_REQUEST_WILD));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_SCRIPT_ERROR_NOTIFY, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_SCRIPT_ERROR_NOTIFY));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_BATTLE_WILD_LOCATION_FAIL, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_BATTLE_WILD_LOCATION_FAIL));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_CANCEL_AURA, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_CANCEL_AURA));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_CAST_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_CAST_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_RENAME, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_RENAME));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_SET_ACTION, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_SET_ACTION));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_SPELL_AUTOCAST, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_SPELL_AUTOCAST));
            handlerDic.Add(REALM_OPCODE.CMSG_PET_STOP_ATTACK, new RealmOpcodeHandlingDelegate(HandleCMSG_PET_STOP_ATTACK));
            handlerDic.Add(REALM_OPCODE.CMSG_PING, new RealmOpcodeHandlingDelegate(HandleCMSG_PING));
            handlerDic.Add(REALM_OPCODE.CMSG_PLAYER_LOGIN, new RealmOpcodeHandlingDelegate(HandleCMSG_PLAYER_LOGIN));
            handlerDic.Add(REALM_OPCODE.CMSG_PROTOCOL_MISMATCH, new RealmOpcodeHandlingDelegate(HandleCMSG_PROTOCOL_MISMATCH));
            handlerDic.Add(REALM_OPCODE.CMSG_PUSH_QUEST_TO_PARTY, new RealmOpcodeHandlingDelegate(HandleCMSG_PUSH_QUEST_TO_PARTY));
            handlerDic.Add(REALM_OPCODE.CMSG_PVP_LOG_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_PVP_LOG_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_PVP_PRESTIGE_RANK_UP, new RealmOpcodeHandlingDelegate(HandleCMSG_PVP_PRESTIGE_RANK_UP));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_BATTLE_PET_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_BATTLE_PET_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_CORPSE_LOCATION_FROM_CLIENT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_CORPSE_LOCATION_FROM_CLIENT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_CORPSE_TRANSPORT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_CORPSE_TRANSPORT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_COUNTDOWN_TIMER, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_COUNTDOWN_TIMER));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_CREATURE, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_CREATURE));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_GAME_OBJECT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_GAME_OBJECT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_GARRISON_CREATURE_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_GARRISON_CREATURE_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_GUILD_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_GUILD_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_INSPECT_ACHIEVEMENTS, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_INSPECT_ACHIEVEMENTS));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_NEXT_MAIL_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_NEXT_MAIL_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_NPC_TEXT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_NPC_TEXT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_PAGE_TEXT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_PAGE_TEXT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_PETITION, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_PETITION));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_PET_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_PET_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_PLAYER_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_PLAYER_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_QUEST_COMPLETION_NPCS, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_QUEST_COMPLETION_NPCS));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_QUEST_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_QUEST_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_QUEST_REWARDS, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_QUEST_REWARDS));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_REALM_NAME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_REALM_NAME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_SCENARIO_POI, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_SCENARIO_POI));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_QUERY_VOID_STORAGE, new RealmOpcodeHandlingDelegate(HandleCMSG_QUERY_VOID_STORAGE));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_CONFIRM_ACCEPT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_CONFIRM_ACCEPT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_ACCEPT_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_ACCEPT_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_CHOOSE_REWARD, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_CHOOSE_REWARD));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_COMPLETE_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_COMPLETE_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_HELLO, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_HELLO));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_QUERY_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_QUERY_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_REQUEST_REWARD, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_REQUEST_REWARD));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_STATUS_MULTIPLE_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_STATUS_MULTIPLE_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_GIVER_STATUS_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_GIVER_STATUS_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_LOG_REMOVE_QUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_LOG_REMOVE_QUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_POI_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_POI_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEST_PUSH_RESULT, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEST_PUSH_RESULT));
            handlerDic.Add(REALM_OPCODE.CMSG_QUEUED_MESSAGES_END, new RealmOpcodeHandlingDelegate(HandleCMSG_QUEUED_MESSAGES_END));
            handlerDic.Add(REALM_OPCODE.CMSG_QUICK_JOIN_AUTO_ACCEPT_REQUESTS, new RealmOpcodeHandlingDelegate(HandleCMSG_QUICK_JOIN_AUTO_ACCEPT_REQUESTS));
            handlerDic.Add(REALM_OPCODE.CMSG_QUICK_JOIN_REQUEST_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_QUICK_JOIN_REQUEST_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_QUICK_JOIN_RESPOND_TO_INVITE, new RealmOpcodeHandlingDelegate(HandleCMSG_QUICK_JOIN_RESPOND_TO_INVITE));
            handlerDic.Add(REALM_OPCODE.CMSG_QUICK_JOIN_SIGNAL_TOAST_DISPLAYED, new RealmOpcodeHandlingDelegate(HandleCMSG_QUICK_JOIN_SIGNAL_TOAST_DISPLAYED));
            handlerDic.Add(REALM_OPCODE.CMSG_RAID_OR_BATTLEGROUND_ENGINE_SURVEY, new RealmOpcodeHandlingDelegate(HandleCMSG_RAID_OR_BATTLEGROUND_ENGINE_SURVEY));
            handlerDic.Add(REALM_OPCODE.CMSG_RANDOM_ROLL, new RealmOpcodeHandlingDelegate(HandleCMSG_RANDOM_ROLL));
            handlerDic.Add(REALM_OPCODE.CMSG_READY_CHECK_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_READY_CHECK_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_READ_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_READ_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_RECLAIM_CORPSE, new RealmOpcodeHandlingDelegate(HandleCMSG_RECLAIM_CORPSE));
            handlerDic.Add(REALM_OPCODE.CMSG_RECRUIT_A_FRIEND, new RealmOpcodeHandlingDelegate(HandleCMSG_RECRUIT_A_FRIEND));
            handlerDic.Add(REALM_OPCODE.CMSG_REDEEM_WOW_TOKEN_CONFIRM, new RealmOpcodeHandlingDelegate(HandleCMSG_REDEEM_WOW_TOKEN_CONFIRM));
            handlerDic.Add(REALM_OPCODE.CMSG_REDEEM_WOW_TOKEN_START, new RealmOpcodeHandlingDelegate(HandleCMSG_REDEEM_WOW_TOKEN_START));
            handlerDic.Add(REALM_OPCODE.CMSG_REMOVE_NEW_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_REMOVE_NEW_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_REORDER_CHARACTERS, new RealmOpcodeHandlingDelegate(HandleCMSG_REORDER_CHARACTERS));
            handlerDic.Add(REALM_OPCODE.CMSG_REPAIR_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_REPAIR_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_REPLACE_TROPHY, new RealmOpcodeHandlingDelegate(HandleCMSG_REPLACE_TROPHY));
            handlerDic.Add(REALM_OPCODE.CMSG_REPOP_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_REPOP_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_REPORT_PVP_PLAYER_AFK, new RealmOpcodeHandlingDelegate(HandleCMSG_REPORT_PVP_PLAYER_AFK));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_ACCOUNT_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_ACCOUNT_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_AREA_POI_UPDATE, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_AREA_POI_UPDATE));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_BATTLEFIELD_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_BATTLEFIELD_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_CATEGORY_COOLDOWNS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_CATEGORY_COOLDOWNS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_CEMETERY_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_CEMETERY_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_CONQUEST_FORMULA_CONSTANTS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_CONQUEST_FORMULA_CONSTANTS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_CONSUMPTION_CONVERSION_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_CONSUMPTION_CONVERSION_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_CROWD_CONTROL_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_CROWD_CONTROL_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_FORCED_REACTIONS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_FORCED_REACTIONS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_GUILD_PARTY_STATE, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_GUILD_PARTY_STATE));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_GUILD_REWARDS_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_GUILD_REWARDS_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_HONOR_STATS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_HONOR_STATS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_LFG_LIST_BLACKLIST, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_LFG_LIST_BLACKLIST));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PARTY_JOIN_UPDATES, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PARTY_JOIN_UPDATES));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PARTY_MEMBER_STATS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PARTY_MEMBER_STATS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PET_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PET_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PLAYED_TIME, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PLAYED_TIME));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PVP_BRAWL_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PVP_BRAWL_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_PVP_REWARDS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_PVP_REWARDS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_RAID_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_RAID_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_RATED_BATTLEFIELD_INFO, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_RATED_BATTLEFIELD_INFO));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_RESEARCH_HISTORY, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_RESEARCH_HISTORY));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_STABLED_PETS, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_STABLED_PETS));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_VEHICLE_EXIT, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_VEHICLE_EXIT));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_VEHICLE_NEXT_SEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_VEHICLE_NEXT_SEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_VEHICLE_PREV_SEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_VEHICLE_PREV_SEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_VEHICLE_SWITCH_SEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_VEHICLE_SWITCH_SEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_WORLD_QUEST_UPDATE, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_WORLD_QUEST_UPDATE));
            handlerDic.Add(REALM_OPCODE.CMSG_REQUEST_WOW_TOKEN_MARKET_PRICE, new RealmOpcodeHandlingDelegate(HandleCMSG_REQUEST_WOW_TOKEN_MARKET_PRICE));
            handlerDic.Add(REALM_OPCODE.CMSG_RESET_CHALLENGE_MODE, new RealmOpcodeHandlingDelegate(HandleCMSG_RESET_CHALLENGE_MODE));
            handlerDic.Add(REALM_OPCODE.CMSG_RESET_CHALLENGE_MODE_CHEAT, new RealmOpcodeHandlingDelegate(HandleCMSG_RESET_CHALLENGE_MODE_CHEAT));
            handlerDic.Add(REALM_OPCODE.CMSG_RESET_INSTANCES, new RealmOpcodeHandlingDelegate(HandleCMSG_RESET_INSTANCES));
            handlerDic.Add(REALM_OPCODE.CMSG_RESURRECT_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_RESURRECT_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_REVERT_MONUMENT_APPEARANCE, new RealmOpcodeHandlingDelegate(HandleCMSG_REVERT_MONUMENT_APPEARANCE));
            handlerDic.Add(REALM_OPCODE.CMSG_RIDE_VEHICLE_INTERACT, new RealmOpcodeHandlingDelegate(HandleCMSG_RIDE_VEHICLE_INTERACT));
            handlerDic.Add(REALM_OPCODE.CMSG_SAVE_CLIENT_VARIABLES, new RealmOpcodeHandlingDelegate(HandleCMSG_SAVE_CLIENT_VARIABLES));
            handlerDic.Add(REALM_OPCODE.CMSG_SAVE_CUF_PROFILES, new RealmOpcodeHandlingDelegate(HandleCMSG_SAVE_CUF_PROFILES));
            handlerDic.Add(REALM_OPCODE.CMSG_SAVE_ENABLED_ADDONS, new RealmOpcodeHandlingDelegate(HandleCMSG_SAVE_ENABLED_ADDONS));
            handlerDic.Add(REALM_OPCODE.CMSG_SAVE_EQUIPMENT_SET, new RealmOpcodeHandlingDelegate(HandleCMSG_SAVE_EQUIPMENT_SET));
            handlerDic.Add(REALM_OPCODE.CMSG_SAVE_GUILD_EMBLEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SAVE_GUILD_EMBLEM));
            handlerDic.Add(REALM_OPCODE.CMSG_SCENE_PLAYBACK_CANCELED, new RealmOpcodeHandlingDelegate(HandleCMSG_SCENE_PLAYBACK_CANCELED));
            handlerDic.Add(REALM_OPCODE.CMSG_SCENE_PLAYBACK_COMPLETE, new RealmOpcodeHandlingDelegate(HandleCMSG_SCENE_PLAYBACK_COMPLETE));
            handlerDic.Add(REALM_OPCODE.CMSG_SCENE_TRIGGER_EVENT, new RealmOpcodeHandlingDelegate(HandleCMSG_SCENE_TRIGGER_EVENT));
            handlerDic.Add(REALM_OPCODE.CMSG_SELF_RES, new RealmOpcodeHandlingDelegate(HandleCMSG_SELF_RES));
            handlerDic.Add(REALM_OPCODE.CMSG_SELL_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SELL_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_SELL_WOW_TOKEN_CONFIRM, new RealmOpcodeHandlingDelegate(HandleCMSG_SELL_WOW_TOKEN_CONFIRM));
            handlerDic.Add(REALM_OPCODE.CMSG_SELL_WOW_TOKEN_START, new RealmOpcodeHandlingDelegate(HandleCMSG_SELL_WOW_TOKEN_START));
            handlerDic.Add(REALM_OPCODE.CMSG_SEND_CONTACT_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_SEND_CONTACT_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_SEND_MAIL, new RealmOpcodeHandlingDelegate(HandleCMSG_SEND_MAIL));
            handlerDic.Add(REALM_OPCODE.CMSG_SEND_SOR_REQUEST_VIA_ADDRESS, new RealmOpcodeHandlingDelegate(HandleCMSG_SEND_SOR_REQUEST_VIA_ADDRESS));
            handlerDic.Add(REALM_OPCODE.CMSG_SEND_TEXT_EMOTE, new RealmOpcodeHandlingDelegate(HandleCMSG_SEND_TEXT_EMOTE));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ACHIEVEMENTS_HIDDEN, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ACHIEVEMENTS_HIDDEN));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ACTION_BAR_TOGGLES, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ACTION_BAR_TOGGLES));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ACTION_BUTTON, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ACTION_BUTTON));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ACTIVE_MOVER, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ACTIVE_MOVER));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ADVANCED_COMBAT_LOGGING, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ADVANCED_COMBAT_LOGGING));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ASSISTANT_LEADER, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ASSISTANT_LEADER));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_BACKPACK_AUTOSORT_DISABLED, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_BACKPACK_AUTOSORT_DISABLED));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_BANK_AUTOSORT_DISABLED, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_BANK_AUTOSORT_DISABLED));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_BANK_BAG_SLOT_FLAG, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_BANK_BAG_SLOT_FLAG));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_CONTACT_NOTES, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_CONTACT_NOTES));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_CURRENCY_FLAGS, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_CURRENCY_FLAGS));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_DIFFICULTY_ID, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_DIFFICULTY_ID));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_DUNGEON_DIFFICULTY, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_DUNGEON_DIFFICULTY));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_EVERYONE_IS_ASSISTANT, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_EVERYONE_IS_ASSISTANT));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_FACTION_AT_WAR, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_FACTION_AT_WAR));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_FACTION_INACTIVE, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_FACTION_INACTIVE));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_FACTION_NOT_AT_WAR, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_FACTION_NOT_AT_WAR));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_INSERT_ITEMS_LEFT_TO_RIGHT, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_INSERT_ITEMS_LEFT_TO_RIGHT));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_LFG_BONUS_FACTION_ID, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_LFG_BONUS_FACTION_ID));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_LOOT_METHOD, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_LOOT_METHOD));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_LOOT_SPECIALIZATION, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_LOOT_SPECIALIZATION));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PARTY_ASSIGNMENT, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PARTY_ASSIGNMENT));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PARTY_LEADER, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PARTY_LEADER));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PET_SLOT, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PET_SLOT));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PLAYER_DECLINED_NAMES, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PLAYER_DECLINED_NAMES));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PREFERRED_CEMETERY, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PREFERRED_CEMETERY));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_PVP, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_PVP));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_RAID_DIFFICULTY, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_RAID_DIFFICULTY));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_ROLE, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_ROLE));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_SAVED_INSTANCE_EXTEND, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_SAVED_INSTANCE_EXTEND));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_SELECTION, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_SELECTION));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_SHEATHED, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_SHEATHED));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_SORT_BAGS_RIGHT_TO_LEFT, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_SORT_BAGS_RIGHT_TO_LEFT));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_TAXI_BENCHMARK_MODE, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_TAXI_BENCHMARK_MODE));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_TITLE, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_TITLE));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_TRADE_CURRENCY, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_TRADE_CURRENCY));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_TRADE_GOLD, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_TRADE_GOLD));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_TRADE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_TRADE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_USING_PARTY_GARRISON, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_USING_PARTY_GARRISON));
            handlerDic.Add(REALM_OPCODE.CMSG_SET_WATCHED_FACTION, new RealmOpcodeHandlingDelegate(HandleCMSG_SET_WATCHED_FACTION));
            handlerDic.Add(REALM_OPCODE.CMSG_SHOW_TRADE_SKILL, new RealmOpcodeHandlingDelegate(HandleCMSG_SHOW_TRADE_SKILL));
            handlerDic.Add(REALM_OPCODE.CMSG_SIGN_PETITION, new RealmOpcodeHandlingDelegate(HandleCMSG_SIGN_PETITION));
            handlerDic.Add(REALM_OPCODE.CMSG_SILENCE_PARTY_TALKER, new RealmOpcodeHandlingDelegate(HandleCMSG_SILENCE_PARTY_TALKER));
            handlerDic.Add(REALM_OPCODE.CMSG_SOCKET_GEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_SOCKET_GEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_SORT_BAGS, new RealmOpcodeHandlingDelegate(HandleCMSG_SORT_BAGS));
            handlerDic.Add(REALM_OPCODE.CMSG_SORT_BANK_BAGS, new RealmOpcodeHandlingDelegate(HandleCMSG_SORT_BANK_BAGS));
            handlerDic.Add(REALM_OPCODE.CMSG_SORT_REAGENT_BANK_BAGS, new RealmOpcodeHandlingDelegate(HandleCMSG_SORT_REAGENT_BANK_BAGS));
            handlerDic.Add(REALM_OPCODE.CMSG_SPELL_CLICK, new RealmOpcodeHandlingDelegate(HandleCMSG_SPELL_CLICK));
            handlerDic.Add(REALM_OPCODE.CMSG_SPIRIT_HEALER_ACTIVATE, new RealmOpcodeHandlingDelegate(HandleCMSG_SPIRIT_HEALER_ACTIVATE));
            handlerDic.Add(REALM_OPCODE.CMSG_SPLIT_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SPLIT_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_STAND_STATE_CHANGE, new RealmOpcodeHandlingDelegate(HandleCMSG_STAND_STATE_CHANGE));
            handlerDic.Add(REALM_OPCODE.CMSG_START_CHALLENGE_MODE, new RealmOpcodeHandlingDelegate(HandleCMSG_START_CHALLENGE_MODE));
            handlerDic.Add(REALM_OPCODE.CMSG_START_SPECTATOR_WAR_GAME, new RealmOpcodeHandlingDelegate(HandleCMSG_START_SPECTATOR_WAR_GAME));
            handlerDic.Add(REALM_OPCODE.CMSG_START_WAR_GAME, new RealmOpcodeHandlingDelegate(HandleCMSG_START_WAR_GAME));
            handlerDic.Add(REALM_OPCODE.CMSG_SUMMON_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_SUMMON_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_SUPPORT_TICKET_SUBMIT_BUG, new RealmOpcodeHandlingDelegate(HandleCMSG_SUPPORT_TICKET_SUBMIT_BUG));
            handlerDic.Add(REALM_OPCODE.CMSG_SUPPORT_TICKET_SUBMIT_COMPLAINT, new RealmOpcodeHandlingDelegate(HandleCMSG_SUPPORT_TICKET_SUBMIT_COMPLAINT));
            handlerDic.Add(REALM_OPCODE.CMSG_SUPPORT_TICKET_SUBMIT_SUGGESTION, new RealmOpcodeHandlingDelegate(HandleCMSG_SUPPORT_TICKET_SUBMIT_SUGGESTION));
            handlerDic.Add(REALM_OPCODE.CMSG_SURRENDER_ARENA, new RealmOpcodeHandlingDelegate(HandleCMSG_SURRENDER_ARENA));
            handlerDic.Add(REALM_OPCODE.CMSG_SUSPEND_COMMS_ACK, new RealmOpcodeHandlingDelegate(HandleCMSG_SUSPEND_COMMS_ACK));
            handlerDic.Add(REALM_OPCODE.CMSG_SUSPEND_TOKEN_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_SUSPEND_TOKEN_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_SWAP_INV_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SWAP_INV_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_SWAP_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SWAP_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_SWAP_SUB_GROUPS, new RealmOpcodeHandlingDelegate(HandleCMSG_SWAP_SUB_GROUPS));
            handlerDic.Add(REALM_OPCODE.CMSG_SWAP_VOID_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_SWAP_VOID_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_TABARD_VENDOR_ACTIVATE, new RealmOpcodeHandlingDelegate(HandleCMSG_TABARD_VENDOR_ACTIVATE));
            handlerDic.Add(REALM_OPCODE.CMSG_TALK_TO_GOSSIP, new RealmOpcodeHandlingDelegate(HandleCMSG_TALK_TO_GOSSIP));
            handlerDic.Add(REALM_OPCODE.CMSG_TAXI_NODE_STATUS_QUERY, new RealmOpcodeHandlingDelegate(HandleCMSG_TAXI_NODE_STATUS_QUERY));
            handlerDic.Add(REALM_OPCODE.CMSG_TAXI_QUERY_AVAILABLE_NODES, new RealmOpcodeHandlingDelegate(HandleCMSG_TAXI_QUERY_AVAILABLE_NODES));
            handlerDic.Add(REALM_OPCODE.CMSG_TAXI_REQUEST_EARLY_LANDING, new RealmOpcodeHandlingDelegate(HandleCMSG_TAXI_REQUEST_EARLY_LANDING));
            handlerDic.Add(REALM_OPCODE.CMSG_TIME_ADJUSTMENT_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_TIME_ADJUSTMENT_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_TIME_SYNC_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_TIME_SYNC_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_TIME_SYNC_RESPONSE_DROPPED, new RealmOpcodeHandlingDelegate(HandleCMSG_TIME_SYNC_RESPONSE_DROPPED));
            handlerDic.Add(REALM_OPCODE.CMSG_TIME_SYNC_RESPONSE_FAILED, new RealmOpcodeHandlingDelegate(HandleCMSG_TIME_SYNC_RESPONSE_FAILED));
            handlerDic.Add(REALM_OPCODE.CMSG_TOGGLE_DIFFICULTY, new RealmOpcodeHandlingDelegate(HandleCMSG_TOGGLE_DIFFICULTY));
            handlerDic.Add(REALM_OPCODE.CMSG_TOGGLE_PVP, new RealmOpcodeHandlingDelegate(HandleCMSG_TOGGLE_PVP));
            handlerDic.Add(REALM_OPCODE.CMSG_TOTEM_DESTROYED, new RealmOpcodeHandlingDelegate(HandleCMSG_TOTEM_DESTROYED));
            handlerDic.Add(REALM_OPCODE.CMSG_TRADE_SKILL_SET_FAVORITE, new RealmOpcodeHandlingDelegate(HandleCMSG_TRADE_SKILL_SET_FAVORITE));
            handlerDic.Add(REALM_OPCODE.CMSG_TRAINER_BUY_SPELL, new RealmOpcodeHandlingDelegate(HandleCMSG_TRAINER_BUY_SPELL));
            handlerDic.Add(REALM_OPCODE.CMSG_TRAINER_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_TRAINER_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_TRANSMOGRIFY_ITEMS, new RealmOpcodeHandlingDelegate(HandleCMSG_TRANSMOGRIFY_ITEMS));
            handlerDic.Add(REALM_OPCODE.CMSG_TURN_IN_PETITION, new RealmOpcodeHandlingDelegate(HandleCMSG_TURN_IN_PETITION));
            handlerDic.Add(REALM_OPCODE.CMSG_TUTORIAL, new RealmOpcodeHandlingDelegate(HandleCMSG_TUTORIAL));
            handlerDic.Add(REALM_OPCODE.CMSG_TWITTER_CHECK_STATUS, new RealmOpcodeHandlingDelegate(HandleCMSG_TWITTER_CHECK_STATUS));
            handlerDic.Add(REALM_OPCODE.CMSG_TWITTER_CONNECT, new RealmOpcodeHandlingDelegate(HandleCMSG_TWITTER_CONNECT));
            handlerDic.Add(REALM_OPCODE.CMSG_TWITTER_DISCONNECT, new RealmOpcodeHandlingDelegate(HandleCMSG_TWITTER_DISCONNECT));
            handlerDic.Add(REALM_OPCODE.CMSG_TWITTER_POST, new RealmOpcodeHandlingDelegate(HandleCMSG_TWITTER_POST));
            handlerDic.Add(REALM_OPCODE.CMSG_UI_TIME_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_UI_TIME_REQUEST));
            handlerDic.Add(REALM_OPCODE.CMSG_UNACCEPT_TRADE, new RealmOpcodeHandlingDelegate(HandleCMSG_UNACCEPT_TRADE));
            handlerDic.Add(REALM_OPCODE.CMSG_UNDELETE_CHARACTER, new RealmOpcodeHandlingDelegate(HandleCMSG_UNDELETE_CHARACTER));
            handlerDic.Add(REALM_OPCODE.CMSG_UNLEARN_SKILL, new RealmOpcodeHandlingDelegate(HandleCMSG_UNLEARN_SKILL));
            handlerDic.Add(REALM_OPCODE.CMSG_UNLEARN_SPECIALIZATION, new RealmOpcodeHandlingDelegate(HandleCMSG_UNLEARN_SPECIALIZATION));
            handlerDic.Add(REALM_OPCODE.CMSG_UNLOCK_VOID_STORAGE, new RealmOpcodeHandlingDelegate(HandleCMSG_UNLOCK_VOID_STORAGE));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_ACCOUNT_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_ACCOUNT_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_AREA_TRIGGER_VISUAL, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_AREA_TRIGGER_VISUAL));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_CLIENT_SETTINGS, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_CLIENT_SETTINGS));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_MISSILE_TRAJECTORY, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_MISSILE_TRAJECTORY));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_RAID_TARGET, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_RAID_TARGET));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_SPELL_VISUAL, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_SPELL_VISUAL));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_VAS_PURCHASE_STATES, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_VAS_PURCHASE_STATES));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST));
            handlerDic.Add(REALM_OPCODE.CMSG_UPDATE_WOW_TOKEN_COUNT, new RealmOpcodeHandlingDelegate(HandleCMSG_UPDATE_WOW_TOKEN_COUNT));
            handlerDic.Add(REALM_OPCODE.CMSG_UPGRADE_GARRISON, new RealmOpcodeHandlingDelegate(HandleCMSG_UPGRADE_GARRISON));
            handlerDic.Add(REALM_OPCODE.CMSG_UPGRADE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_UPGRADE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_USED_FOLLOW, new RealmOpcodeHandlingDelegate(HandleCMSG_USED_FOLLOW));
            handlerDic.Add(REALM_OPCODE.CMSG_USE_CRITTER_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_USE_CRITTER_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_USE_EQUIPMENT_SET, new RealmOpcodeHandlingDelegate(HandleCMSG_USE_EQUIPMENT_SET));
            handlerDic.Add(REALM_OPCODE.CMSG_USE_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_USE_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_USE_TOY, new RealmOpcodeHandlingDelegate(HandleCMSG_USE_TOY));
            handlerDic.Add(REALM_OPCODE.CMSG_VIOLENCE_LEVEL, new RealmOpcodeHandlingDelegate(HandleCMSG_VIOLENCE_LEVEL));
            handlerDic.Add(REALM_OPCODE.CMSG_VOID_STORAGE_TRANSFER, new RealmOpcodeHandlingDelegate(HandleCMSG_VOID_STORAGE_TRANSFER));
            handlerDic.Add(REALM_OPCODE.CMSG_WARDEN_DATA, new RealmOpcodeHandlingDelegate(HandleCMSG_WARDEN_DATA));
            handlerDic.Add(REALM_OPCODE.CMSG_WHO, new RealmOpcodeHandlingDelegate(HandleCMSG_WHO));
            handlerDic.Add(REALM_OPCODE.CMSG_WHO_IS, new RealmOpcodeHandlingDelegate(HandleCMSG_WHO_IS));
            handlerDic.Add(REALM_OPCODE.CMSG_WORLD_PORT_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_WORLD_PORT_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_WRAP_ITEM, new RealmOpcodeHandlingDelegate(HandleCMSG_WRAP_ITEM));
            handlerDic.Add(REALM_OPCODE.CMSG_BF_MGR_ENTRY_INVITE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_BF_MGR_ENTRY_INVITE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_BF_MGR_QUEUE_INVITE_RESPONSE, new RealmOpcodeHandlingDelegate(HandleCMSG_BF_MGR_QUEUE_INVITE_RESPONSE));
            handlerDic.Add(REALM_OPCODE.CMSG_BF_MGR_QUEUE_EXIT_REQUEST, new RealmOpcodeHandlingDelegate(HandleCMSG_BF_MGR_QUEUE_EXIT_REQUEST));
            #endregion            
        }

        private static RealmReceiveBufferHandler singletonHandle;

        private delegate bool RealmOpcodeHandlingDelegate(RealmClientSession pmTargetSession);
        private Dictionary<REALM_OPCODE, RealmOpcodeHandlingDelegate> handlerDic;

        public static void HandleRealmOpcode(RealmClientSession pmTargetSession, REALM_OPCODE pmOpcode)
        {
            if (singletonHandle == null)
            {
                singletonHandle = new RealmReceiveBufferHandler();
            }

            if (!singletonHandle.handlerDic[pmOpcode](pmTargetSession))
            {
                MLogger.RuntimeLogger.Error(pmOpcode.ToString() + " handle failed.");
            }
        }

        #region handler methods
        private bool HandleCMSG_COMMENTATOR_ENABLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_RAID_WARNING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLENET_REQUEST_REALM_LIST_TICKET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_ACK_FAILED_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_CONFIRM_PURCHASE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_DISTRIBUTION_ASSIGN_TO_TARGET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_GET_PRODUCT_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_GET_PURCHASE_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_QUERY_CLASS_TRIAL_BOOST_RESULT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_REQUEST_CHARACTER_BOOST_UNREVOKE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_REQUEST_CURRENT_VAS_TRANSFER_QUEUES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_REQUEST_PRICE_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_REQUEST_VAS_CHARACTER_QUEUE_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_START_PURCHASE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_START_VAS_PURCHASE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_TRIAL_BOOST_CHARACTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PAY_VALIDATE_BNET_VAS_TRANSFER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_CLEAR_FANFARE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_DELETE_PET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_DELETE_PET_CHEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_MODIFY_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_REQUEST_JOURNAL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_REQUEST_JOURNAL_LOCK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_SET_BATTLE_SLOT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_SET_FLAGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_SUMMON(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLE_PET_UPDATE_NOTIFY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BEGIN_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BINDER_ACTIVATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BLACK_MARKET_BID_ON_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BLACK_MARKET_OPEN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BLACK_MARKET_REQUEST_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUG_REPORT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUSY_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_BACK_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_BANK_SLOT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_REAGENT_BANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_WOW_TOKEN_CONFIRM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BUY_WOW_TOKEN_START(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CAGE_BATTLE_PET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_ADD_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_COMPLAIN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_COPY_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_EVENT_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_EVENT_MODERATOR_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_EVENT_RSVP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_EVENT_SIGN_UP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_EVENT_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_GET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_GET_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_GET_NUM_PENDING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_GUILD_FILTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_REMOVE_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_REMOVE_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CALENDAR_UPDATE_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_AURA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_AUTO_REPEAT_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_CAST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_CHANNELLING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_GROWTH_AURA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_MASTER_LOOT_ROLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_MOD_SPEED_NO_CONTROL_AURAS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_MOUNT_AURA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_QUEUED_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_TEMP_ENCHANTMENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CANCEL_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CAN_DUEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CAN_REDEEM_WOW_TOKEN_FOR_BALANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CAST_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHALLENGE_MODE_REQUEST_LEADERS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHALLENGE_MODE_REQUEST_MAP_STATS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHANGE_BAG_SLOT_FLAG(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHANGE_MONUMENT_APPEARANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHANGE_SUB_GROUP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHARACTER_RENAME_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAR_CUSTOMIZE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAR_DELETE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAR_RACE_OR_FACTION_CHANGE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_CHANNEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_GUILD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_INSTANCE_CHAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_OFFICER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_PARTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_RAID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_ADDON_MESSAGE_WHISPER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_ANNOUNCEMENTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_BAN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_DECLINE_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_DISPLAY_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_KICK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_MODERATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_MODERATOR(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_MUTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_OWNER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_PASSWORD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_SET_OWNER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_SILENCE_ALL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_UNBAN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_UNMODERATOR(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_UNMUTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_CHANNEL_UNSILENCE_ALL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_JOIN_CHANNEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_LEAVE_CHANNEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_AFK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_CHANNEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_DND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_EMOTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_GUILD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_INSTANCE_CHAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_OFFICER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_PARTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_RAID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_SAY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_WHISPER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_MESSAGE_YELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_REGISTER_ADDON_PREFIXES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_REPORT_FILTERED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_REPORT_IGNORED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHAT_UNREGISTER_ALL_ADDON_PREFIXES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHECK_RAF_EMAIL_ENABLED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHECK_WOW_TOKEN_VETERAN_ELIGIBILITY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CHOICE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CLEAR_RAID_MARKER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CLEAR_TRADE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CLIENT_PORT_GRAVEYARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CLOSE_INTERACTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COLLECTION_ITEM_SET_FAVORITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_ENTER_INSTANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_EXIT_INSTANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONTRIBUTION_GET_STATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONFIRM_RESPEC_WIPE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMPLETE_CINEMATIC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_GET_MAP_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_GET_PLAYER_COOLDOWNS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_GET_PLAYER_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMMENTATOR_START_WARGAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMPLAINT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_COMPLETE_MOVIE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONFIRM_ARTIFACT_RESPEC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONNECT_TO_FAILED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONTRIBUTION_CONTRIBUTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONVERT_CONSUMPTION_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CONVERT_RAID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CREATE_CHARACTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_CREATE_SHIPMENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DB_QUERY_BULK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DECLINE_GUILD_INVITES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DECLINE_PETITION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DELETE_EQUIPMENT_SET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DEL_FRIEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DEL_IGNORE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DEPOSIT_REAGENT_BANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DESTROY_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_BOOT_PLAYER_VOTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_GET_JOIN_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_GET_SYSTEM_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_JOIN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_LEAVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_PROPOSAL_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_READY_CHECK_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_SET_ROLES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DF_TELEPORT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DISCARDED_TIME_SYNC_ACKS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DISMISS_CRITTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DO_MASTER_LOOT_ROLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DO_READY_CHECK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_DUEL_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_EJECT_PASSENGER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_EMOTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENABLE_ENCRYPTION_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENABLE_NAGLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENABLE_TAXI_NODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENGINE_SURVEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENUM_CHARACTERS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ENUM_CHARACTERS_DELETED_BY_CLIENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_FAR_SIGHT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GAME_OBJ_REPORT_USE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GAME_OBJ_USE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_ASSIGN_FOLLOWER_TO_BUILDING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_CANCEL_CONSTRUCTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_CHECK_UPGRADEABLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_COMPLETE_MISSION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_GENERATE_RECRUITS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_GET_BUILDING_LANDMARKS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_GET_MISSION_REWARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_MISSION_BONUS_ROLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_PURCHASE_BUILDING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_RECRUIT_FOLLOWER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REMOVE_FOLLOWER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REMOVE_FOLLOWER_FROM_BUILDING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_RENAME_FOLLOWER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REQUEST_BLUEPRINT_AND_SPECIALIZATION_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REQUEST_CLASS_SPEC_CATEGORY_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REQUEST_LANDING_PAGE_SHIPMENT_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_RESEARCH_TALENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_SET_BUILDING_ACTIVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_SET_FOLLOWER_FAVORITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_SET_FOLLOWER_INACTIVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_SET_RECRUITMENT_PREFERENCES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_START_MISSION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GENERATE_RANDOM_CHARACTER_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_SWAP_BUILDINGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_CHALLENGE_MODE_REWARDS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GARRISON_REQUEST_SHIPMENT_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_GARRISON_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_ITEM_PURCHASE_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_MIRROR_IMAGE_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_PVP_OPTIONS_ENABLED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_REMAINING_GAME_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_TROPHY_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GET_UNDELETE_CHARACTER_COOLDOWN_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GM_TICKET_ACKNOWLEDGE_SURVEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GM_TICKET_GET_CASE_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GM_TICKET_GET_SYSTEM_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GOSSIP_SELECT_OPTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GRANT_LEVEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_ADD_BATTLENET_FRIEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_ADD_RANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_ASSIGN_MEMBER_RANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_AUTO_DECLINE_INVITATION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_ACTIVATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_BUY_TAB(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_DEPOSIT_MONEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_LOG_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_QUERY_TAB(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_SET_TAB_TEXT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_SWAP_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_TEXT_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_UPDATE_TAB(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_BANK_WITHDRAW_MONEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_CHALLENGE_UPDATE_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_CHANGE_NAME_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_DECLINE_INVITATION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_DELETE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_DELETE_RANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_DEMOTE_MEMBER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_EVENT_LOG_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_GET_ACHIEVEMENT_MEMBERS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_GET_RANKS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_GET_ROSTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_INVITE_BY_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_LEAVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_MEMBER_SEND_SOR_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_NEWS_UPDATE_STICKY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_OFFICER_REMOVE_MEMBER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_PERMISSIONS_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_PROMOTE_MEMBER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_QUERY_MEMBERS_FOR_RECIPE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_QUERY_MEMBER_RECIPES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_QUERY_NEWS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_QUERY_RECIPES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_REPLACE_GUILD_MASTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SET_ACHIEVEMENT_TRACKING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SET_FOCUSED_ACHIEVEMENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SET_GUILD_MASTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SET_MEMBER_NOTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SET_RANK_PERMISSIONS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_SHIFT_RANK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_UPDATE_INFO_TEXT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_GUILD_UPDATE_MOTD_TEXT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_HEARTH_AND_RESURRECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_HOTFIX_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_IGNORE_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_INITIATE_ROLE_POLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_INITIATE_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_INSPECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_INSPECT_PVP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_INSTANCE_LOCK_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ITEM_PURCHASE_REFUND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ITEM_TEXT_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_JOIN_PET_BATTLE_QUEUE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_JOIN_RATED_BATTLEGROUND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_KEEP_ALIVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_KEYBOUND_OVERRIDE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LEARN_PVP_TALENTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LEARN_TALENTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LEAVE_GROUP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LEAVE_PET_BATTLE_QUEUE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_APPLY_TO_GROUP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_CANCEL_APPLICATION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_DECLINE_APPLICANT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_GET_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_INVITE_APPLICANT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_INVITE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_JOIN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_LEAVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_SEARCH(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LFG_LIST_UPDATE_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_ADD_RECRUIT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_BROWSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_DECLINE_RECRUIT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_GET_APPLICATIONS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_GET_GUILD_POST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_GET_RECRUITS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_REMOVE_RECRUIT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LF_GUILD_SET_GUILD_POST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LIST_INVENTORY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LIVE_REGION_ACCOUNT_RESTORE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LIVE_REGION_CHARACTER_COPY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LIVE_REGION_GET_ACCOUNT_CHARACTER_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOADING_SCREEN_NOTIFY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOAD_SELECTED_TROPHY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOGOUT_CANCEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOGOUT_INSTANT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOGOUT_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOG_DISCONNECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOG_STREAMING_ERROR(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOOT_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOOT_MONEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOOT_RELEASE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOOT_ROLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOOT_UNIT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOW_LEVEL_RAID1(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_LOW_LEVEL_RAID2(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_CREATE_TEXT_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_DELETE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_GET_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_MARK_AS_READ(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_RETURN_TO_SENDER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_TAKE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MAIL_TAKE_MONEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MASTER_LOOT_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MINIMAP_PING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MISSILE_TRAJECTORY_COLLISION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOUNT_CLEAR_FANFARE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOUNT_SET_FAVORITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOUNT_SPECIAL_ANIM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_APPLY_MOVEMENT_FORCE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_CHANGE_TRANSPORT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_CHANGE_VEHICLE_SEATS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_DISMISS_VEHICLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_DOUBLE_JUMP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_ENABLE_DOUBLE_JUMP_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FALL_LAND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FALL_RESET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FEATHER_FALL_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_PITCH_RATE_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_ROOT_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_SWIM_BACK_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_TURN_RATE_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_UNROOT_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_GRAVITY_DISABLE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_GRAVITY_ENABLE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_HEARTBEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_HOVER_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_JUMP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_KNOCK_BACK_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_REMOVE_MOVEMENT_FORCES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_REMOVE_MOVEMENT_FORCE_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_CAN_FLY_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_CAN_TURN_WHILE_FALLING_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_COLLISION_HEIGHT_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_FACING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_FLY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_IGNORE_MOVEMENT_FORCES_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_PITCH(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_RUN_MODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_VEHICLE_REC_ID_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SET_WALK_MODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_SPLINE_DONE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_ASCEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_BACKWARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_DESCEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_STRAFE_RIGHT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_FORWARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_PITCH_DOWN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_PITCH_UP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_STRAFE_LEFT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_SWIM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_TURN_LEFT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_START_TURN_RIGHT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP_ASCEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP_PITCH(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP_STRAFE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP_SWIM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_STOP_TURN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_TELEPORT_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_TIME_SKIPPED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPENING_CINEMATIC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_NEXT_CINEMATIC_CAMERA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_TOGGLE_COLLISION_CHEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_MOVE_WATER_WALK_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_NEUTRAL_PLAYER_SELECT_FACTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OBJECT_UPDATE_FAILED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OBJECT_UPDATE_RESCUED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OFFER_PETITION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPEN_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPEN_MISSION_NPC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPEN_SHIPMENT_NPC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPEN_TRADESKILL_NPC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_OPT_OUT_OF_LOOT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PARTY_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PARTY_INVITE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PARTY_UNINVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PETITION_BUY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PETITION_RENAME_GUILD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PETITION_SHOW_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PETITION_SHOW_SIGNATURES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_ABANDON(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_ACTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_FINAL_NOTIFY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_INPUT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_QUEUE_PROPOSE_MATCH_RESULT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_QUIT_NOTIFY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_REPLACE_FRONT_PET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_REQUEST_PVP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_REQUEST_UPDATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_REQUEST_WILD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_SCRIPT_ERROR_NOTIFY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_BATTLE_WILD_LOCATION_FAIL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_CANCEL_AURA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_CAST_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_RENAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_SET_ACTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_SPELL_AUTOCAST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PET_STOP_ATTACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PLAYER_LOGIN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PROTOCOL_MISMATCH(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PUSH_QUEST_TO_PARTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PVP_LOG_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_PVP_PRESTIGE_RANK_UP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_BATTLE_PET_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_CORPSE_LOCATION_FROM_CLIENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_CORPSE_TRANSPORT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_COUNTDOWN_TIMER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_CREATURE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_GAME_OBJECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_GARRISON_CREATURE_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_GUILD_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_INSPECT_ACHIEVEMENTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_NEXT_MAIL_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_NPC_TEXT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_PAGE_TEXT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_PETITION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_PET_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_PLAYER_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_QUEST_COMPLETION_NPCS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_QUEST_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_QUEST_REWARDS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_REALM_NAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_SCENARIO_POI(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUERY_VOID_STORAGE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_CONFIRM_ACCEPT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_ACCEPT_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_CHOOSE_REWARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_COMPLETE_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_HELLO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_QUERY_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_REQUEST_REWARD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_STATUS_MULTIPLE_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_GIVER_STATUS_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_LOG_REMOVE_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_POI_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEST_PUSH_RESULT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUEUED_MESSAGES_END(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUICK_JOIN_AUTO_ACCEPT_REQUESTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUICK_JOIN_REQUEST_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUICK_JOIN_RESPOND_TO_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_QUICK_JOIN_SIGNAL_TOAST_DISPLAYED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RAID_OR_BATTLEGROUND_ENGINE_SURVEY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RANDOM_ROLL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_READY_CHECK_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_READ_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RECLAIM_CORPSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RECRUIT_A_FRIEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REDEEM_WOW_TOKEN_CONFIRM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REDEEM_WOW_TOKEN_START(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REMOVE_NEW_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REORDER_CHARACTERS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REPAIR_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REPLACE_TROPHY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REPOP_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REPORT_PVP_PLAYER_AFK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_ACCOUNT_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_AREA_POI_UPDATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_BATTLEFIELD_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_CATEGORY_COOLDOWNS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_CEMETERY_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_CONQUEST_FORMULA_CONSTANTS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_CONSUMPTION_CONVERSION_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_CROWD_CONTROL_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_FORCED_REACTIONS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_GUILD_PARTY_STATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_GUILD_REWARDS_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_HONOR_STATS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_LFG_LIST_BLACKLIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PARTY_JOIN_UPDATES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PARTY_MEMBER_STATS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PET_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PLAYED_TIME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PVP_BRAWL_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_PVP_REWARDS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_RAID_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_RATED_BATTLEFIELD_INFO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_RESEARCH_HISTORY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_STABLED_PETS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_VEHICLE_EXIT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_VEHICLE_NEXT_SEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_VEHICLE_PREV_SEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_VEHICLE_SWITCH_SEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_WORLD_QUEST_UPDATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REQUEST_WOW_TOKEN_MARKET_PRICE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RESET_CHALLENGE_MODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RESET_CHALLENGE_MODE_CHEAT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RESET_INSTANCES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RESURRECT_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_REVERT_MONUMENT_APPEARANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_RIDE_VEHICLE_INTERACT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SAVE_CLIENT_VARIABLES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SAVE_CUF_PROFILES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SAVE_ENABLED_ADDONS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SAVE_EQUIPMENT_SET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SAVE_GUILD_EMBLEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SCENE_PLAYBACK_CANCELED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SCENE_PLAYBACK_COMPLETE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SCENE_TRIGGER_EVENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SELF_RES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SELL_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SELL_WOW_TOKEN_CONFIRM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SELL_WOW_TOKEN_START(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SEND_CONTACT_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SEND_MAIL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SEND_SOR_REQUEST_VIA_ADDRESS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SEND_TEXT_EMOTE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ACHIEVEMENTS_HIDDEN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ACTION_BAR_TOGGLES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ACTION_BUTTON(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ACTIVE_MOVER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ADVANCED_COMBAT_LOGGING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ASSISTANT_LEADER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_BACKPACK_AUTOSORT_DISABLED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_BANK_AUTOSORT_DISABLED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_BANK_BAG_SLOT_FLAG(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_CONTACT_NOTES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_CURRENCY_FLAGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_DIFFICULTY_ID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_DUNGEON_DIFFICULTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_EVERYONE_IS_ASSISTANT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_FACTION_AT_WAR(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_FACTION_INACTIVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_FACTION_NOT_AT_WAR(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_INSERT_ITEMS_LEFT_TO_RIGHT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_LFG_BONUS_FACTION_ID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_LOOT_METHOD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_LOOT_SPECIALIZATION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PARTY_ASSIGNMENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PARTY_LEADER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PET_SLOT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PLAYER_DECLINED_NAMES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PREFERRED_CEMETERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_PVP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_RAID_DIFFICULTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_ROLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_SAVED_INSTANCE_EXTEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_SELECTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_SHEATHED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_SORT_BAGS_RIGHT_TO_LEFT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_TAXI_BENCHMARK_MODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_TITLE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_TRADE_CURRENCY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_TRADE_GOLD(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_TRADE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_USING_PARTY_GARRISON(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SET_WATCHED_FACTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SHOW_TRADE_SKILL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SIGN_PETITION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SILENCE_PARTY_TALKER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SOCKET_GEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SORT_BAGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SORT_BANK_BAGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SORT_REAGENT_BANK_BAGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SPELL_CLICK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SPIRIT_HEALER_ACTIVATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SPLIT_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_STAND_STATE_CHANGE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_START_CHALLENGE_MODE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_START_SPECTATOR_WAR_GAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_START_WAR_GAME(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUMMON_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUPPORT_TICKET_SUBMIT_BUG(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUPPORT_TICKET_SUBMIT_COMPLAINT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUPPORT_TICKET_SUBMIT_SUGGESTION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SURRENDER_ARENA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUSPEND_COMMS_ACK(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SUSPEND_TOKEN_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SWAP_INV_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SWAP_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SWAP_SUB_GROUPS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_SWAP_VOID_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TABARD_VENDOR_ACTIVATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TALK_TO_GOSSIP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TAXI_NODE_STATUS_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TAXI_QUERY_AVAILABLE_NODES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TAXI_REQUEST_EARLY_LANDING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TIME_ADJUSTMENT_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TIME_SYNC_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TIME_SYNC_RESPONSE_DROPPED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TIME_SYNC_RESPONSE_FAILED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TOGGLE_DIFFICULTY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TOGGLE_PVP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TOTEM_DESTROYED(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TRADE_SKILL_SET_FAVORITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TRAINER_BUY_SPELL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TRAINER_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TRANSMOGRIFY_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TURN_IN_PETITION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TUTORIAL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TWITTER_CHECK_STATUS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TWITTER_CONNECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TWITTER_DISCONNECT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_TWITTER_POST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UI_TIME_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UNACCEPT_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UNDELETE_CHARACTER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UNLEARN_SKILL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UNLEARN_SPECIALIZATION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UNLOCK_VOID_STORAGE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_ACCOUNT_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_AREA_TRIGGER_VISUAL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_CLIENT_SETTINGS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_MISSILE_TRAJECTORY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_RAID_TARGET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_SPELL_VISUAL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_VAS_PURCHASE_STATES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_WOW_TOKEN_AUCTIONABLE_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPDATE_WOW_TOKEN_COUNT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPGRADE_GARRISON(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_UPGRADE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_USED_FOLLOW(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_USE_CRITTER_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_USE_EQUIPMENT_SET(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_USE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_USE_TOY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_VIOLENCE_LEVEL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_VOID_STORAGE_TRANSFER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_WARDEN_DATA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_WHO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_WHO_IS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_WORLD_PORT_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_WRAP_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BF_MGR_ENTRY_INVITE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BF_MGR_QUEUE_INVITE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BF_MGR_QUEUE_EXIT_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLENET_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLENET_CHALLENGE_RESPONSE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEMASTER_JOIN_SKIRMISH(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEMASTER_JOIN_BRAWL(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEMASTER_JOIN_ARENA(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEMASTER_JOIN(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEMASTER_HELLO(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEFIELD_PORT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEFIELD_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BATTLEFIELD_LEAVE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_BANKER_ACTIVATE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTO_STORE_BAG_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTO_EQUIP_ITEM_SLOT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTO_EQUIP_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTOSTORE_BANK_REAGENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTOSTORE_BANK_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTOBANK_REAGENT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTOBANK_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTH_SESSION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUTH_CONTINUED_SESSION(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_SELL_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_REPLICATE_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_REMOVE_ITEM(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_PLACE_BID(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_LIST_PENDING_SALES(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_LIST_OWNER_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_LIST_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_LIST_BIDDER_ITEMS(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AUCTION_HELLO_REQUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ATTACK_SWING(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ATTACK_STOP(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ASSIGN_EQUIPMENT_SET_SPEC(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ARTIFACT_SET_APPEARANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ARTIFACT_ADD_POWER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AREA_TRIGGER(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AREA_SPIRIT_HEALER_QUEUE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_AREA_SPIRIT_HEALER_QUERY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ALTER_APPEARANCE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADVENTURE_JOURNAL_START_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADVENTURE_JOURNAL_OPEN_QUEST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADD_TOY(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADD_IGNORE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADD_FRIEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADD_BATTLENET_FRIEND(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ADDON_LIST(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ACTIVATE_TAXI(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ACCEPT_WARGAME_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ACCEPT_TRADE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ACCEPT_LEVEL_GRANT(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleCMSG_ACCEPT_GUILD_INVITE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }

        private bool HandleNONE(RealmClientSession pmTargetSession)
        {
            bool result = true; result = false; return result;
        }
        #endregion
    }
}