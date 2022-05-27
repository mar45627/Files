#pragma once
#include "VisualConstructor/VisualMob.h"
#include "VisualConstructor/VisualMount.h"
#include "VisualConstructor/VisCharacterTemplate.h"
#include "Scene/VisObjectTemplate.h"
#include "Sound/FMODProject.h"
#include "Scene3D/Geometry.h"
#include "Scene3D/SkeletalAnimation.h"
#include "VisualConstructor/AnimationProperties.h"
#include "RenderCommon/Texture.h"
#include "VisualConstructor/MobAnimations.h"

#include "Map\ZoneInfo.h"

#include "Scene3D\AstralMaterialParams.h"
#include "Scene3D\CommonMaterialParams.h"
#include "Scene3D\PointLitMaterialParams.h"
#include "Scene3D\SkyMaterialParams.h"

#include "SLON\AlignCollisionComponent.h"
#include "VisualConstructor\AnimationFromParentComponent.h"
#include "VisualConstructor\AstralComponent.h"
#include "SLON\AttachCameraSlotComponent.h"
#include "Scene\AttachedVisObjectComponent.h"
#include "SLON\CameraPathComponent.h"
#include "SLON\CameraShakerComponent.h"
#include "Scene\ChainAnimatorComponent.h"
#include "SLON\ChannelingComponent.h"
#include "Scene\ColorMaskComponent.h"
#include "SLON\CustomIdleComponent.h"
#include "VisualConstructor\DayTimeComponent.h"
#include "Scene\DelayComponent.h"
#include "SLON\GuildColorsMaskComponent.h"
#include "Scene\LightComponent.h"
#include "VisualConstructor\LightMutatorComponent.h"
#include "Scene\RandomComponent.h"
#include "SLON\ServerTimeComponent.h"
#include "VisualConstructor\SkyObject.h"
#include "VisualConstructor\StateComponent.h"
#include "Scene\StopVisObjectComponents.h"
#include "VisualConstructor\SunShaftsComponent.h"
#include "Scene\TimeTransparencyComponent.h"
#include "SLON\TLVisualComponent.h"
#include "VisualConstructor\TrailComponent.h"
#include "Scene\VisObjComponentsFile.h"
#include "Map\WeatherVisObjComponent.h"

#include "VisualConstructor\VisualMobTroopExtension.h"

#include "Replica\AstralSpellChanneling.h"

#include "Replica\CameraParametersAction.h"
#include "SLON\CameraTrackAction.h"
#include "Replica\CreatureAnimationAction.h"
#include "Replica\CreatureAnimationFromCasterAction.h"
#include "Replica\CreatureAnimationSetModeAction.h"
#include "Replica\CreatureAnimationSetSpeedAction.h"
#include "Replica\CreatureAnimationStopAction.h"
#include "Replica\CreatureAstralSpellFXVisAction.h"
#include "Replica/AstralSpellProjectile.h"
#include "Replica/CreatureAttachSelfAction.h"
#include "Replica/CreatureAttackTargetVisAction.h"
#include "Replica/CreatureCancelMountHidingVisAction.h"
#include "Replica/CreatureChangeAppearanceAction.h"
#include "Replica/CreatureChangeVisItemsAction.h"
#include "Widgets/UISingleTexture.h"
#include "Widgets/UITexture.h"
#include "VisualConstructor/VisualMountClass.h"
#include "Animation/ParticleAnimation.h"
#include "Scene/ClolorFromPrimeSecondary.h"
#include "RenderCommon/TextureSingleElement.h"
#include "VisualConstructor/CharacterVariations.h"
#include "VisualConstructor/VICAttachedComponentByCharFiltered.h"
#include "VisualConstructor/VICDynamic.h"
#include "VisualConstructor/VICHideAttachedObj.h"
#include "VisualConstructor/VICReplaceTexture.h"
#include "VisualConstructor/VICStatic.h"
#include "VisualConstructor/VICVisObjectByCharComponent.h"
#include "VisualConstructor/VICCancelDefaultDressSlotSettings.h"
#include "VisualConstructor/VICHideGeosets.h"
#include "VisualConstructor/VICHideUnderwear.h"
#include "VisualConstructor/VICOverride.h"
#include "VisualConstructor/VICPack.h"
#include "VisualConstructor/VICSelectByChar.h"
#include "VisualConstructor/VICSelectComponentByChar.h"
#include "VisualConstructor/VICSelectComponentByGuildLevel.h"
#include "VisualConstructor/VICSelectComponentByRankInGuild.h"
#include "VisualConstructor/VICUsePack.h"
#include "VisualConstructor/VICVisObjectComponents.h"
#include "VisualConstructor/VisualItemGrades.h"
#include "Replica/VisItemEffectsRanged.h"
#include "VisualConstructor/VisCharacterTraceProperties.h"
#include "VisualConstructor/VisEffectBaseList.h"
#include "RenderCommon/MaterialTemplate.h"
#include "VisualConstructor/TexturePatch.h"
#include "VisualConstructor/ModelMorphSettings.h"
#include "SLON/EffectsList.h"
#include "VisualConstructor/CharacterSoundVariation.h"
#include "VisualConstructor/IndexedTexture.h"
#include "VisualConstructor/TrailTemplate.h"
#include "Map/SoundObjectData.h"
#include "Collision/Collision.h"
#include "Collision/CollisionMesh.h"
#include "Collision/PhysicMaterial.h"
#include "Terrain/FoliageGeometry.h"
#include "VisualConstructor/SkyMesh.h"
#include "Scene3D/AnimationController.h"
#include "VisualConstructor/SpellVisScripts.h"
#include "Replica/CreatureChannelDirectAction.h"
#include "Replica/VisPointFromEventClientDataPlus.h"
#include "Replica/VisPointLocator.h"
#include "Replica/EffectOffendConstDelay.h"
#include "Replica/EffectOffendConstVelocity.h"
#include "Replica/CreatureChargedSpellAction.h"
#include "Replica/CreatureColorAction.h"
#include "SLON/CreatureDisableEmotesAction.h"
#include "SLON/CreatureDisableHitsAction.h"
#include "Replica/CreatureDisableSpecialIdlesAction.h"
#include "Replica/CreatureEffectsAction.h"
#include "Replica/CreatureEffectsOnTarget.h"
#include "Replica/CreatureEnchantWeaponAction.h"
#include "SLON/CreatureEnlargeFovAction.h"
#include "Replica/CreatureEventPlaybackEnded.h"
#include "SLON/CreatureFatalityAbilityAction.h"
#include "Replica/CreatureFixedPointProjectileAction.h"
#include "Replica/CreatureFixedTimeProjectileAction.h"
#include "SLON/CreatureForceMoveAction.h"
#include "SLON/CreatureGridViewAction.h"
#include "Replica/CreatureHeavyProjectileAction.h"
#include "Replica/CreatureHideMountVisAction.h"
#include "Replica/CreatureHoldWeaponAction.h"
#include "Replica/CreatureIfFlagVisAction.h"
#include "Replica/CreatureIfMainAvatarRunAction.h"
#include "SLON/CreatureIndependentFxAction.h"
#include "Replica/CreatureItemAnimationAction.h"
#include "Replica/CreatureItemAttachBoneAction.h"
#include "SLON/CreatureLockTargetAction.h"
#include "Replica/CreatureMountVisAction.h"
#include "Replica/CreatureMusicParamAction.h"
#include "Replica/DayTimeParameter.h"
#include "Replica/GuildLevelParameter.h"
#include "Replica/HaloRankParameter.h"
#include "Replica/HealthParameter.h"
#include "Replica/LevelParameter.h"
#include "Replica/RankInGuildParameter.h"
#include "Replica/ThreatParameter.h"
#include "Replica/CreatureOnCreationVisAction.h"
#include "Replica/CreatureOnParameterChangedAction.h"
#include "Replica/CreatureParalyzeAction.h"
#include "Replica/CreaturePetVisAction.h"
#include "Replica/CreatureProjectileAction.h"
#include "Replica/CreatureReplaceAnimationAction.h"
#include "Replica/CreatureReplaceAnimationsAction.h"
#include "Replica/CreatureRunActionOnSpellTargets.h"
#include "SLON/CreatureRunOnAllAction.h"
#include "Replica/CreatureRunVisActionResource.h"
#include "Replica/CreatureSayAction.h"
#include "Replica/CreatureScaleAction.h"
#include "SLON/CreatureSceneDesaturationAction.h"
#include "Replica/CreatureSetAnimationPropertiesAction.h"
#include "SLON/CreatureSetFlagAction.h"
#include "Replica/CreatureSetFlagVisAction.h"
#include "SLON/CreatureSetPortraitAction.h"
#include "SLON/CreatureSetSwimHeightAction.h"
#include "Replica/CreatureSetTransparencyAction.h"
#include "SLON/CreatureSheathAction.h"
#include "Replica/CreatureShowHaloAction.h"
#include "SLON/CreatureStepSoundParamAction.h"
#include "Replica/CreatureSwitchDistToTargetAction.h"
#include "Replica/CreatureTakeArrowAction.h"
#include "Replica/CreatureTakeBowStringAction.h"
#include "Replica/CreatureThrowArrowAction.h"
#include "Replica/CreatureTimeIntervalChannelPosAction.h"
#include "Replica/CreatureTimeIntervalChannelSpeedAction.h"
#include "Replica/CreatureTimeIntervalEndAnimationAction.h"
#include "Replica/CreatureTrailAction.h"
#include "Replica/CreatureTurnToMainAvatarAction.h"
#include "Replica/CreatureTurnToTargetAction.h"
#include "Replica/CreatureUseIntervalsVisAction.h"
#include "Replica/CreatureVisActionCreateController.h"
#include "Replica/CreatureVisActionIgnoreDisarm.h"
#include "Replica/CreatureVisActionOnSelectableTargets.h"
#include "Replica/CreatureVisActionPlayOnUsedDevice.h"
#include "Replica/DeviceAnimationAction.h"
#include "Replica/DeviceCannonLaunchedAction.h"
#include "Replica/DeviceChannelAction.h"
#include "Replica/DeviceColorAction.h"
#include "Replica/DeviceFixedPointProjectileAction.h"
#include "Replica/DeviceIfFlagVisAction.h"
#include "Replica/DeviceVisActionAutoStop.h"
#include "Replica/DeviceVisActionChangeModel.h"
#include "Replica/DeviceVisActionDelay.h"
#include "Replica/DeviceVisActionList.h"
#include "Replica/DeviceVisActionLoopAction.h"
#include "Replica/DeviceVisEffectsAction.h"
#include "Replica/EntityVisActionIfVisObject.h"
#include "Replica/ShowSceneAction.h"
#include "Replica/Sound3DActionDevice.h"
#include "Replica/CreatureVisActionStartThrow.h"
#include "SLON/CreatureVisObjectComponentsAction.h"
#include "Replica/CreatureWaitReadyAction.h"
#include "Replica/CreatureWaitThrowDurationAction.h"
#include "SLON/DisableNavigationTeleportAction.h"
#include "SLON/HighlightCreatureVisAction.h"
#include "Replica/LooterEmoteAction.h"
#include "Replica/PostEffectVisAction.h"
#include "VisualConstructor/UserPostEffect.h"
#include "SLON/PredicateCreatureFlagAction.h"
#include "Replica/ProceduralEffectVisAction.h"
#include "Replica/ShakeAction.h"
#include "VisualConstructor/CameraShakeParameters.h"
#include "Replica/ShiftAction.h"
#include "Replica/Sound2DAction.h"
#include "Replica/Sound2DMatchAction.h"
#include "Replica/Sound3DAction.h"
#include "Replica/VisActionChangeVisObject.h"
#include "Replica/VisActionDelay.h"
#include "Replica/VisActionList.h"
#include "Replica/VisActionLoopAction.h"
#include "Replica/VisActionRandom.h"
#include "Replica/VisActionRefCounter.h"
#include "Replica/VisActionStopAction.h"
#include "SLON/WeatherCreatureVisAction.h"
#include "VisualConstructor/AreaEffect.h"
#include "Replica/BuffVisScripts.h"
#include "SLON/SlonRoot.h"
